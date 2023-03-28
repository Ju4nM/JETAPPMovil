using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMNotificaciones : BaseViewModel
    {
        #region VARIABLES
        string _descripcion = "La temperatura es normal";
        DateTime _fecha; 

        #endregion
        #region CONSTRUCTOR
        public VMNotificaciones(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetValue(ref _descripcion, value); }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { SetValue(ref _fecha, value);}
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        #endregion
    }
}
