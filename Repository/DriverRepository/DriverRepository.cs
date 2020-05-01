using Model;
using Repository.UserDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DriverRepository
{
   public class DriverRepository:IDriverRepository
    {
        private readonly UserDbContext userContext;
        int capacity = 10;
        int vehicleCount;

        public DriverRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }
        public int CheckLotAvailability()
        {
            if(capacity>=vehicleCount)
                return 1;
            return 0;
        }

        public IEnumerable<ParkingModel> GetAllVehicle()
        {
            return userContext.ParkingSpace;
        }

        public Task<int> AddParking(ParkingModel vehicle)
        {
            int slot = CheckLotAvailability();
            if (slot == 1)
            {
                userContext.ParkingSpace.Add(vehicle);
                var result = userContext.SaveChangesAsync();
                vehicleCount++;
                return result;
            }
            else if (slot == 0)
            {
                throw new ParkingLotException("Lot not available");
            }
            return null;
        }

        public ParkingModel GetVehicle(int slotNumber)
        {
            return userContext.ParkingSpace.Find(slotNumber);
        }
        public double ParkingCharge(int slotNumber)
        {
            ParkingModel parking = userContext.ParkingSpace.Find(slotNumber);
                DateTime entryTime = parking.EntryTime;
                DateTime exit = DateTime.Now;
            double totalTime = (entryTime - exit).TotalMinutes;
            if(parking.ParkingType.Equals("vallet",StringComparison.InvariantCultureIgnoreCase) &&
                parking.DriverCategory.Equals("PH",StringComparison.InvariantCultureIgnoreCase))
            {
                return totalTime * 0;
            }
            if (parking.ParkingType.Equals("own", StringComparison.InvariantCultureIgnoreCase) &&
               parking.DriverCategory.Equals("Normal", StringComparison.InvariantCultureIgnoreCase))
            {
                if (totalTime <= 1)
                    return 10;
            }
            if (parking.VehicalType.Equals("TwoWheelers", StringComparison.InvariantCultureIgnoreCase)
                {
                return totalTime * parking.ChargesPerHour;
                }
           else if(parking.VehicalType.Equals("FourWheelers", StringComparison.InvariantCultureIgnoreCase)
                {
                return totalTime * parking.ChargesPerHour;

            }
            return 0.0;
        public Task<int> Parkking(ParkingModel parking)
        {
            this.userContext.ParkingSpace.Add(parking); 
            var result = this.userContext.SaveChangesAsync();
            return result;
        }

        public string UnParking(int ParkingSlotId)
        {
            ParkingModel parking = this.userContext.ParkingSpace.Find(ParkingSlotId);
            this.userContext.ParkingSpace.Remove(parking);
            return Utility.Receipt(parking.ChargesPerHour, parking.EntryTime);
        }
    }
}
