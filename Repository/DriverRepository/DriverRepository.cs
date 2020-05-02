using Model;
using Repository.UserDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DriverRepository
{
   public class DriverRepository : IDriverRepository
    {
        private readonly UserDbContext userContext;
        int lotCapacity = 10;
        int vehicleCount=0;

        public DriverRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }
        public int CheckLotAvailability()
        {
            if(lotCapacity>=vehicleCount)
                return 1;
            return 0;
        }

        public IEnumerable<ParkingModel> GetAllVehicle()
        {
            return userContext.ParkingSpace;
        }
        public ParkingModel GetVehicle(int slotNumber)
        {
            return userContext.ParkingSpace.Find(slotNumber);
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

       
        public double ParkingCharge(int slotNumber)
        {
            ParkingModel parking = userContext.ParkingSpace.Find(slotNumber);
            DateTime entryTime = parking.EntryTime;
            DateTime exitTime = DateTime.Now;
            double totalTime = (entryTime - exitTime).TotalHours;
            if (parking.ParkingType.Equals("valet Parking", StringComparison.InvariantCultureIgnoreCase) &&
                parking.DriverCategory.Equals("PH", StringComparison.InvariantCultureIgnoreCase))
            {
                return totalTime * 0;
            }
            else if (parking.ParkingType.Equals("own", StringComparison.InvariantCultureIgnoreCase) &&
                parking.DriverCategory.Equals("Normal", StringComparison.InvariantCultureIgnoreCase))
            {
                if (totalTime <= 1)
                    return 10;
            }
            if (parking.VehicalType.Equals("TwoWheelers", StringComparison.InvariantCultureIgnoreCase))
            {
                return totalTime * parking.ChargesPerHour;
            }
            else if (parking.VehicalType.Equals("FourWheelers", StringComparison.InvariantCultureIgnoreCase))
            {
                return totalTime * parking.ChargesPerHour;

            }
            return 0.0;
        }
        public ParkingModel UnParking(int slotNumber)
        {
            ParkingModel parking = userContext.ParkingSpace.Find(slotNumber);
            int index = slotNumber;
            if(parking!=null)
            {
                userContext.ParkingSpace.Remove(parking);
                userContext.SaveChanges();
            }
            return parking;
        }
    }
}
