using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMDeleteUser : BaseViewModel
    {
        
            #region VARIABLES
            string _Id;

            #endregion
            #region CONSTRUCTOR
            public VMDeleteUser(INavigation navigation)
            {
                Navigation = navigation;
            }
            #endregion
            #region OBJETOS
            public string ID
            {
                get { return _Id; }
                set { SetProperty(ref _Id, value); }
            }

            #endregion
            #region PROCESOS
            public async Task Delete()
            {
            await DisplayAlert("Sistema","Desea eliminar el usuario", "Aceptar");
            
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"https://jetapi.onrender.com/users/{ID}");
                request.Method = HttpMethod.Delete;
                request.Headers.Add("Accept", "application/json");
                var cliente = new HttpClient();
                HttpResponseMessage response = await cliente.DeleteAsync($"https://jetapi.onrender.com/users/{ID}");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Sistema", "Usuario eliminado", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Sistema", "No se pudo eliminar al usuario", "Aceptar");
                }
            ID = "";
            }

            #endregion
            #region COMANDOS
            public ICommand DeleteCommand => new Command(async () => await Delete());
            #endregion
        
    }
}
