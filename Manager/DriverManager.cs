using Model;
using Repository.DriverRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class DriverManager:IDriverManager
    {
    
            private readonly IDriverRepository driverRepository;

            public DriverManager(IDriverRepository driverRepository)
            {
                this.driverRepository = driverRepository;
            }

            public Task<int> Parkking(ParkingModel parking)
            {
                return this.driverRepository.Parkking(parking);
            }

            public string UnParking(int parkingSlotId)
            {
                return this.driverRepository.UnParking(parkingSlotId);
            }
        }
}
