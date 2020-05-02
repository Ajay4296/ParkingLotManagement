using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OwnerRepository
{
   public  interface IOwnerRepository
    {
        Task<int> AddParking();
        ParkingModel GetVehicle();
        ParkingModel RemoveVehicle();
    }
}
