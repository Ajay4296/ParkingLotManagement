using Model;
using Repository.policeRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class PoliceManager:IPoliceManager
    {
        private readonly IPoliceRepository policeRepository;

        public PoliceManager(IPoliceRepository Repository)
        {
            this.policeRepository = policeRepository;
        }
        public ParkingModel GetVehicle(int slotNumber)
        {
            return this.policeRepository.GetVehicle(slotNumber);
        }
        public Task<int> AddParking(ParkingModel parking)
        {
            return this.policeRepository.AddParking(parking);
        }
        public ParkingModel UnParking(int parkingSlotId)
        {
            return this.policeRepository.UnPark(parkingSlotId);
        }
    }
}
