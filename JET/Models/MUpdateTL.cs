using System;
using System.Collections.Generic;
using System.Text;

namespace JET.Models
{
    // This class is to define the data will be send to update the temperature limit
    class MUpdateTL
    {
        public double limitTemperature { get; set; }
        public string user { get; set; }
    }
}
