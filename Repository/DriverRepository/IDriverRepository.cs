using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DriverRepository
{
   public interface IDriverRepository
    {
        int CheckLotAvailability();
        IEnumerable<ParkingModel> GetAllVehicle();
        ParkingModel GetVehicle(int slotNumber);
        Task<int> AddParking(ParkingModel vehicle);
        double ParkingCharge(int slotNumber);
        ParkingModel UnParking(int slotNumber);
    }
}
