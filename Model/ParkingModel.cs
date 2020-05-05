using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class ParkingModel
    {
           [Key]
             public int ParkingSlotNo { get; set; }

         [Required]
             public string VehicalNo { get; set; }

            [Required]
            public string VehicalType { get; set; }
         [Required]
            public int ChargesPerHour { get; set; }

          [Required]
            public DateTime EntryTime { get; set; }

            [Required]
            public string DriverCategory { get; set; }

            [Required]
            public string ParkingType { get; set; }

           
        }
}
