using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ParkingLotManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
  
            private readonly ISecurityManager securityManager;

            public SecurityController(ISecurityManager securityManager)
            {
                this.securityManager = securityManager;
            }
            [Route("GetVehicle")]
            [HttpGet]
            public ParkingModel Get_Vehicle(int slotNumber)
            {
                return this.securityManager.GetVehicle(slotNumber);

            }
            [Route("ParkVahical")]
            [HttpPost]
            public async Task<IActionResult> Parking_Vahical(ParkingModel parking)
            {
                var result = await this.securityManager.AddParking(parking);
                if (result == 1)
                    return this.Ok(parking);

                return this.BadRequest();
            }
            [Route("UnParkVahical")]
            [HttpDelete]
            public ParkingModel UnParkVahicle(int ParkingSlotId)
            {
                return this.securityManager.UnParking(ParkingSlotId);
            }

        }
    }