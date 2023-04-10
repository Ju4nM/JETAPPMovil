using JET.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JET.Models
{
    public class sensor: BaseViewModel
    {
        string _temperatureLimit;
        public string temperatureLimit {
            get => _temperatureLimit;
            set => SetProperty(ref  _temperatureLimit, value);
        }
    }
    public class rele: BaseViewModel
    {
        bool _state;
        public bool state {
            get => _state; 
            set => SetProperty(ref _state, value);
        }
    }
    public class MDevice: BaseViewModel
    {
        sensor _sensor;
        rele _rele;
        public sensor sensor {
            get => _sensor;
            set => SetProperty(ref _sensor, value);
        }
        
        public rele rele {
            get => _rele;
            set => SetProperty(ref _rele, value);
        }
    }
}
