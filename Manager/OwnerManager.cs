using Model;
using Repository.OwnerRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class OwnerManager :IOwnerManager
    {
        private readonly IOwnerRepository ownerRepository;

        public OwnerManager(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }
        public IEnumerable<ParkingModel> GetAllVehicle()
        {
            return this.ownerRepository.GetAllVehicle();
        }
       public Task<int> AddParking(ParkingModel parking)
        {
            return this.ownerRepository.AddParking(parking);
        }
       public ParkingModel UnParking(int parkingSlotId)
        {
            return this.ownerRepository.UnPark(parkingSlotId);
        }
    }
}
