using JET.Data;
using JET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMControl: BaseViewModel
    {
        #region variables
        int _currentLimit;
        int _limitToDisplay;
        string _testigo;
        Temperatures _temActual;
        MDevice _dispositivos;
        bool _fanStatus;
        bool deviceDataLoaded = false;
        #endregion

        #region objetos
        public bool FanStatus
        {
            get => _fanStatus;
            set {
                if (deviceDataLoaded)
                {
                    _ = ToggleFan();
                } else
                {
                    SetProperty(ref _fanStatus, value);
                }
            }
        }
        MDevice Dispositivos
        {
            get => _dispositivos;
            set => SetProperty(ref _dispositivos, value);
        }
        public int CurrentLimit
        {
            get => _currentLimit;
            set => SetProperty(ref _currentLimit, value);
        }
        public int LimitToDisplay
        {
            get => _limitToDisplay;
            set => SetProperty(ref _limitToDisplay, value);
        }
        public string Testigo
        {
            get => _testigo;
            set => SetProperty(ref _testigo, value);
        }
        public Temperatures TemActual
        {
            get => _temActual;
            set => SetProperty(ref _temActual, value);
        }
        #endregion

        #region constructor
        public VMControl (INavigation nav)
        {
            Navigation = nav;
            Init();
        }
        public void Init ()
        {
            _ = ExtraerTemActual();
            _ = GetDeviceData();
        }
        #endregion

        #region procesos
        public async Task ExtraerTemActual()
        {
            TemActual = await DTemperatures.ExtraerTemActual();  
        }

        public async Task GetDeviceData ()
        {
            Dispositivos = await DDevices.GetDeviceData();
            FanStatus = Dispositivos.rele.state;
            Testigo = FanStatus ? "Encendido" : "Apagado";
            CurrentLimit = LimitToDisplay = int.Parse(Dispositivos.sensor.temperatureLimit);
            deviceDataLoaded = true;
        }

        public async Task ToggleFan ()
        {
            HttpResponseMessage response = await DDevices.ToggleFan();

            bool currentState = FanStatus;
            if (response.StatusCode != HttpStatusCode.Created)
            {
                string action = !currentState ? "encender" : "apagar";
                await DisplayAlert("Error", $"Ha ocurrido un error al intentar {action} la ventilacion", "Aceptar");
                return;
            }
            string content = await response.Content.ReadAsStringAsync();
            ToggledFanResponse responseDeserialized = JsonConvert.DeserializeObject<ToggledFanResponse>(content);
            SetProperty(ref _fanStatus, responseDeserialized.releStatus);
        }

        public async Task UpdateTemperatureLimit ()
        {
            HttpResponseMessage response = await DTemperatureLimit.UpdateTemperatureLimit(CurrentLimit);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Aviso", "Se ha actualizado la temperatura limite", "Aceptar");
                LimitToDisplay = CurrentLimit;
                return;
            }
            await DisplayAlert("Error", "Ha ocurrido un error al intentar actualizar el limite de temperatura", "Aceptar");
            CurrentLimit = LimitToDisplay;
        }
        #endregion

        public void RedirectToBrowser ()
        {
            //Device.OpenUri(new Uri("http://jetapptest.somee.com/#/today-chart"));
            Launcher.CanOpenAsync(new Uri("http://jetapptest.somee.com/#/today-chart"));
        }

        #region commands
        public ICommand UpdateLimitCommand => new Command(async () => await UpdateTemperatureLimit());

        public ICommand OpenWebAppCommand => new Command(RedirectToBrowser);
        #endregion
    }
}
