using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
   public class DriverManager:IDriverManager
    {
        public class DriverManager : IDriverManager
        {
            private readonly IDriverRepository driverRepository;

            public DriverManager(IDriverRepository driverRepository)
            {
                this.driverRepository = driverRepository;
            }

            public Task<int> Parkking(Parking parking)
            {
                return this.driverRepository.Parkking(parking);
            }

            public string UnParking(int parkingSlotId)
            {
                return this.driverRepository.UnParking(parkingSlotId);
            }
        }
}
