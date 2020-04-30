using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingLotManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverManager driverManager;

        public DriverController(IDriverManager driverManager)
        {
            this.driverManager = driverManager;
        }

        [Route("ParkVahical")]
        [HttpPost]
        public async Task<IActionResult> Parking_Vahical(Parking parking)
        {
            var result = await this.driverManager.Park(parking);
            if (result == 1)
                return this.Ok(parking);

            return this.BadRequest();
        }

        [Route("UnParkVahical")]
        [HttpDelete]
        public string UnParking_Vahical(int ParkingSlotId)
        {
            return this.driverManager.UnParking(ParkingSlotId);
        }
    }
}