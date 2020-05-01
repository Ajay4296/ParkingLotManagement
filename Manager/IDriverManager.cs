using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public interface IDriverManager
    {
        Task<int> Parkking(ParkingModel parking);
        string UnParking(int parkingSlotId);
    }
}
