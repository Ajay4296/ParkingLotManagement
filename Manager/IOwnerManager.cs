using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public interface IOwnerManager
    {
        IEnumerable<ParkingModel> GetAllVehicle();
        Task<int> AddParking(ParkingModel parking);
        ParkingModel UnParking(int parkingSlotId);

    }
}
