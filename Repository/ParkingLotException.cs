using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class ParkingLotException:Exception
    {
        public ParkingLotException(string msg) : base(msg)
        {

        }
    }
}
