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
       public static int lotCapacity = 10;
        int vehicleCount=0;
        private ParkingModel parking;

        // public static List<ParkingModel> list = new List<ParkingModel>();

        public DriverRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }
        public int CheckLotAvailability()
        {
            if(lotCapacity>vehicleCount)
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
            //int slot = CheckLotAvailability(); 
                    userContext.ParkingSpace.Add(vehicle);
                    var result = userContext.SaveChangesAsync();
                    vehicleCount++;
                     return result;
        } 

       
        public string ParkingCharge(int slotNumber)
        {
           // ParkingModel parking = userContext.ParkingSpace.Find(slotNumber);
           // DateTime entryTime = parking.EntryTime;
          //  DateTime exitTime = DateTime.Now;
            
            if (parking.ParkingType.Equals("valet Parking", StringComparison.InvariantCultureIgnoreCase) &&
                parking.DriverCategory.Equals("POS", StringComparison.InvariantCultureIgnoreCase))
            {
                 return ("Parking Entry Time = " + parking.EntryTime + "@\n" + "Parking Exit Time = " + DateTime.Now + "@\n" + "Parking Charges = " + (DateTime.Now-parking.EntryTime)*0);
               
            }
            else if (parking.ParkingType.Equals("own", StringComparison.InvariantCultureIgnoreCase) &&
                parking.DriverCategory.Equals("Normal", StringComparison.InvariantCultureIgnoreCase))
            {
                return ("Parking Entry Time = " + parking.EntryTime + "@\n" + "Parking Exit Time = " + DateTime.Now + "@\n" + "Parking Charges = " + (DateTime.Now - parking.EntryTime) * parking.ChargesPerHour);
            }
            if (parking.VehicalType.Equals("TwoWheelers", StringComparison.InvariantCultureIgnoreCase))
            {
                return ("Parking Entry Time = " + parking.EntryTime + "@\n" + "Parking Exit Time = " + DateTime.Now + "@\n" + "Parking Charges = " + (DateTime.Now - parking.EntryTime) * parking.ChargesPerHour);
            }
            else if (parking.VehicalType.Equals("FourWheelers", StringComparison.InvariantCultureIgnoreCase))
            {
                return ("Parking Entry Time = " + parking.EntryTime + "@\n" + "Parking Exit Time = " + DateTime.Now + "@\n" + "Parking Charges = " + (DateTime.Now - parking.EntryTime) * parking.ChargesPerHour);
            }
            return null;
        }
        public string UnParking(int slotNumber)
        {
            ParkingModel parking = userContext.ParkingSpace.Find(slotNumber);
            int index = slotNumber;
            try
            {
                if (parking == null)
                    throw new ParkingLotException("This slot id is empty");
                userContext.ParkingSpace.Remove(parking);
                userContext.SaveChanges();
                return ParkingCharge(slotNumber);
            }
            catch (ParkingLotException e)
            {
                return e.Message;
            }
            
        }
    }
}
