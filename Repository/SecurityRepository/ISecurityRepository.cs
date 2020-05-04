﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SecurityRepository
{
    public interface ISecurityRepository
    {
        Task<int> AddParking(ParkingModel vehicle);
        ParkingModel GetVehicle(int slotNumber);
        ParkingModel UnPark(int slotNumber);
    }
}
