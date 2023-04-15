using System;
using System.Collections.Generic;
using System.Text;

namespace JET.Models
{
    public class MChangeHistory
    {
        public bool? state { get; set; }

        public MTemperatureLimit limitTemperature { get; set; } = null;
        public UserModel user { get; set; } = null;
        public string changeType { get; set; }
        public DateTime dateOfChange { get; set; }
    }
}
