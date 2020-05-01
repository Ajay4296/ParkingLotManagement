using Model;
using Repository.UserDBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DriverRepository
{
   public class DriverRepository:IDriverRepository
    {
        private readonly UserDbContext userContext;

        public DriverRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }

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
