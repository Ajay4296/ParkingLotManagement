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
        ParkingModel  UnParking(int parkingSlotId);

        ParkingModel Get_Vehicle(int slotNumber);

        IEnumerable<ParkingModel> GetALLVehicle();
        double ParkingCharge(int slotNuber);
    }
}
