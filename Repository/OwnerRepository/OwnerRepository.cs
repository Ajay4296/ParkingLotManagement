using Model;
using Repository.UserDBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.OwnerRepository
{
   public class OwnerRepository : IOwnerRepository
    {
        private readonly UserDbContext userContext;
        public OwnerRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }
        public ParkingModel GetVehicle(int slotNumber)
        {
            return userContext.ParkingSpace.Find(slotNumber);
        }
        public ParkingModel AddParking()
    }
}
