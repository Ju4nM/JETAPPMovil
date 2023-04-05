using JET.Data;
using JET.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMTemperatures : BaseViewModel
    {
        #region VARIABLES
        public int _Tem;
        public string _Testigo;
        
        ObservableCollection<Temperatures> _Temperaturas;
        LimitTemperatures _LimitTemperaturas;
        Temperatures _TemActual;
        #endregion
        #region CONSTRUCTOR
        
        public VMTemperatures(INavigation navigation)
        {
            Navigation = navigation;
            _ = ExtraerTemperatura();
            _ = ExtraerTemLimite();
            _ = ExtraerTemActual();

        }
        #endregion
        #region OBJETOS
        public int Tem
        {
            get { return _Tem; }
            set { SetValue(ref _Tem, value); }
        }
        public string Testigo
        {
            get { return _Testigo; }
            set { SetValue(ref _Testigo, value); }
        }
        public Temperatures TemActual
        {
            get { return _TemActual; }
            set { SetValue(ref _TemActual, value); }
        }
        public LimitTemperatures limitTemperaturas
        {
            get { return _LimitTemperaturas; }
            set { SetValue(ref _LimitTemperaturas, value); }
        }
        public ObservableCollection<Temperatures> Temperaturas
        {
            get { return _Temperaturas; }
            set { SetValue(ref _Temperaturas, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ExtraerTemperatura()
        {
            Temperaturas = await DTemperatures.ExtraerTemperatura();
        }
        public async Task ExtraerTemLimite()
        {
            limitTemperaturas = await DTemperatures.ExtraerTemLimite();
            if(limitTemperaturas.rele.state == true)
            {
                Testigo = "Encendido";
            }
            else
            {
                Testigo = "Apagado";
            }
        }
        public async Task ExtraerTemActual()
        {
            TemActual = await DTemperatures.ExtraerTemActual();  
        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        //public ICommand ProcesoAsyncomand => new Command(async () => await ExtraerTemperatura());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        #endregion
    }
}
