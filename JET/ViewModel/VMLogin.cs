using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using JET.Models;

namespace JET.ViewModel
{
    public class VMLogin: BaseViewModel
    {

        #region Variables
        string _userName;
        string _password;

        string url = AppConfig.url;
        //List<UserModel> _usuario;
        #endregion

        #region Objetos
        /*public List<UserModel> Usuario 
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value);
                OnpropertyChanged();
            }
        }*/
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        #endregion

        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
        }
        #region Procesos
        public class userAuth
        {

            public string userName { get; set; }
            public string password { get; set; }
        }
        public async Task Login()
        {

            var user = new userAuth()
            {
                userName = UserName,
                password = Password
            };
            var json = JsonConvert.SerializeObject(user);
            var contentjson = new StringContent(json, Encoding.UTF8, "application/json");
            Uri requestUri = new Uri($"{url}/auth");
            var cliente = new HttpClient();
            var response = await cliente.PostAsync(requestUri, contentjson);
            var resultado = await response.Content.ReadAsStringAsync();
            var respuesta = JsonConvert.DeserializeObject<MUserLogged>(resultado);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // save locally
                Application.Current.Properties["id"] = respuesta.id;
                Application.Current.Properties["userName"] = respuesta.userName;
                Application.Current.Properties["userType"] = respuesta.userType;
                Application.Current.Properties["isLogged"] = true;

                // Notify appshell
                MessagingCenter.Send(respuesta, "LoginSuccess");

                await Application.Current.SavePropertiesAsync();
                await DisplayAlert("Bienvenido", "Ha iniciado sesión como: " + UserName.ToString(), "OK");
                await Shell.Current.GoToAsync($"//AboutView");


            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                await DisplayAlert("Error", "Usuario y/o contraseña erroneas", "Aceptar");
            }
            else
            {
                //Debug.WriteLine(resultado);
                await DisplayAlert("Mensaje", "No hubo respuesta del Servidor", "OK");
            }
            //await Shell.Current.GoToAsync($"//AboutView");
            UserName = "";
            Password = "";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand => new Command(async () => await Login());
        #endregion
    }
}
