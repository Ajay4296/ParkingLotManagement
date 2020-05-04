using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
      public  interface IPoliceManager
    {
        ParkingModel GetVehicle(int slotNumber);
        Task<int> AddParking(ParkingModel parking);
        ParkingModel UnParking(int parkingSlotId);
    }
}
