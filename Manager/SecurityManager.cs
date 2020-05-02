using Model;
using Repository.SecurityRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
     public class SecurityManager:ISecurityManager
    {
        private readonly ISecurityRepository securityRepository;

        public SecurityManager(ISecurityRepository ownerRepository)
        {
            this.securityRepository = securityRepository;
        }
        public ParkingModel GetVehicle(int slotNumber)
        {
            return this.securityRepository.GetVehicle(slotNumber);
        }
        public Task<int> AddParking(ParkingModel parking)
        {
            return this.securityRepository.AddParking(parking);
        }
        public ParkingModel UnParking(int parkingSlotId)
        {
            return this.securityRepository.UnPark(parkingSlotId);
        }
    }
}
