using Model;
using Repository.UserDBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.policeRepository
{
   public class PoliceRepository:IPoliceRepository
    {
        private readonly UserDbContext userContext;
        public PoliceRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }
        public ParkingModel GetVehicle(int slotNumber)
        {
            return userContext.ParkingSpace.Find(slotNumber);
        }
        public Task<int> AddParking(ParkingModel vehicle)
        {
            userContext.ParkingSpace.Add(vehicle);
            var result = userContext.SaveChangesAsync();
            return result;
        }
        public ParkingModel UnPark(int slotNumber)
        {
            ParkingModel parking = userContext.ParkingSpace.Find(slotNumber);
            if (parking != null)
            {
                userContext.ParkingSpace.Remove(parking);
                userContext.SaveChanges();
            }
            return parking;
        }

    }
}
