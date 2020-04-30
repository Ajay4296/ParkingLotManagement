using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DriverRepository
{
   public interface IDriverRepository
    {
        Task<int> Parkking(Parking parking);
        string UnParking(int ParkingSlotId);
    }
}
