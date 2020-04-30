using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class ParkingModel
    {
           [Key]
            public string VehicalNo { get; set; }

            
            public string VehicalType { get; set; }

            public int ChargesPerHour { get; set; }

          
            public DateTime EntryTime { get; set; }

            
            public string DriverCategory { get; set; }

            
            public string ParkingType { get; set; }

           
        }
}
