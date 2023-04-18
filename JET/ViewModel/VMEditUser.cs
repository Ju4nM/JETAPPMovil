using JET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMEditUser : BaseViewModel
    {
        #region VARIABLES
        string _id;
        string _email;
        string _name;
        string _username;
        string _password;
        string _firstlastname1;
        string _firstlastname2;
        ObservableCollection<UserModel> _editarUser;
        string url = $"{AppConfig.url}/users";

        #endregion
        #region CONSTRUCTOR
        public VMEditUser(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<UserModel> EditarUsers
        {
            get { return _editarUser; }
            set
            {
                SetProperty(ref _editarUser, value);
                OnpropertyChanged();
            }
        }
        public string ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Names
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public string apellidopaterno
        {
            get { return _firstlastname1; }
            set { SetProperty(ref _firstlastname1, value); }
        }
        public string apellidomaterno
        {
            get { return _firstlastname2; }
            set { SetProperty(ref _firstlastname2, value); }
        }
        #endregion
        #region PROCESOS
        public async Task UserEdit()
        {
            var EditarUsuario = new UserModel
            {
                id = ID,
                names = Names,
                firstLastName = apellidopaterno,
                secondLastName = apellidomaterno,
                userName = UserName,
                email = Email,
                password = Password,
            };
            var json = JsonConvert.SerializeObject(EditarUsuario);
            var contentjson = new StringContent(json, Encoding.UTF8, "application/json");
            Uri requestUri = new Uri($"https://jetapi.onrender.com/users/{ID}");
            var cliente = new HttpClient();
            var response = await cliente.PutAsync(requestUri, contentjson);
            var resultado = await response.Content.ReadAsStringAsync();
            var respuesta = JsonConvert.DeserializeObject<UserModel>(resultado);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Mensaje", "Usuario editado con exito", "Aceptar");


            }
            else
            {
                await DisplayAlert("Error", "No se pudo editar el usuario", "Aceptar");
            }
            ID = "";
            Names = "";
            apellidopaterno = "";
            apellidomaterno = "";
            UserName = "";
            Email = "";
            Password = "";
        }
        #endregion
        #region COMANDOS
        //public ICommand ProcesoAsyncomand => new Command(async () => await modificarUser());
        public ICommand UserEditcomand => new Command(async () => await UserEdit());
        #endregion
    }
}
