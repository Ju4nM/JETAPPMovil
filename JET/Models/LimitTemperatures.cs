using System;
using System.Collections.Generic;
using System.Text;

namespace JET.Models
{
    public class sensor
    {
        public string temperatureLimit { get; set; }
    }
    public class rele
    {
        public bool state { get; set; }
    }
    public class LimitTemperatures
    {
        public sensor sensor { get; set; }
        
        public rele rele { get; set; }
    }
}
