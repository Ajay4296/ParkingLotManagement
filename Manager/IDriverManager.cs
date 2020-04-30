using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
   public interface IDriverManager
    {
        Task<int> Parkking(Parking parking);
        string UnParking(int parkingSlotId);
    }
}
