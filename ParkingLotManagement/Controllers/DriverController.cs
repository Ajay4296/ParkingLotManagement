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
    public class DriverController : ControllerBase
    {
        private readonly IDriverManager driverManager;

        public DriverController(IDriverManager driverManager)
        {
            this.driverManager = driverManager;
        }

        [Route("ParkVahical")]
        [HttpPost]
        public async Task<IActionResult> Parking_Vahical(ParkingModel parking)
        {
            var result = await this.driverManager.AddParking(parking);
            if (result == 1)
                return this.Ok(parking);

            return this.BadRequest();
        }

        [Route("UnParkVahical")]
        [HttpDelete]
        public string UnParkVahicle(int ParkingSlotId)
        {
            return this.driverManager.UnParking(ParkingSlotId);
        }

        [Route("GetAllVehicle")]
        [HttpGet]
        public IEnumerable<ParkingModel> GetAll()
        {
            return this.driverManager.GetALLVehicle();
        }
        [Route("GetVehicle")]
        [HttpGet]
        public ParkingModel Get_Vehicle(int slotNumber)
        {
            return this.driverManager.Get_Vehicle(slotNumber);
            
        }
        /*[Route("GetParkingCharge ")]
        [HttpGet]
        public async Task<IActionResult> GetParkingCharge(int slotNumber)
        {
            var result = driverManager.ParkingCharge(slotNumber);
            if (result != null)
                return Ok(result);

            return this.BadRequest();
        }*/
    }
}