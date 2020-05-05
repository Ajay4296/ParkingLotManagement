using Model;
using Repository.UserDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OwnerRepository
{
   public class OwnerRepository : IOwnerRepository
    {
        private readonly UserDbContext userContext;
        public OwnerRepository(UserDbContext userContext)
        {
            this.userContext = userContext;
        }
        public IEnumerable<ParkingModel> GetAllVehicle()
        {
            return userContext.ParkingSpace;
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
