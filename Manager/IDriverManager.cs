using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public interface IDriverManager
    {
        Task<int> AddParking(ParkingModel parking);
        string  UnParking(int parkingSlotId);

        ParkingModel Get_Vehicle(int slotNumber);

        IEnumerable<ParkingModel> GetALLVehicle();
        string ParkingCharge(int slotNuber);
    }
}
