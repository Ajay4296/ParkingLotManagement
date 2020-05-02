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

            public Task<int>AddParking(ParkingModel parking)
            {
                return this.driverRepository.AddParking(parking);
            }

            public ParkingModel UnParking(int parkingSlotId)
            {
                return this.driverRepository.UnParking(parkingSlotId);
            }
            public  ParkingModel Get_Vehicle(int slotNumber)
            {
                 return this.driverRepository.GetVehicle(slotNumber);
             }
           public IEnumerable<ParkingModel> GetALLVehicle()
        {
            return this.driverRepository.GetAllVehicle();
        }
          public double ParkingCharge(int slotNumber)
        {
            return driverRepository.ParkingCharge(slotNumber);
        } 

    }
}
