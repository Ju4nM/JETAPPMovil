using JET.Data;
using JET.Models;
using JET.View.DashboardViews;
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
    public class VMUsers: BaseViewModel
    {

        #region Variables
        string _email;
        string _name;
        string _username;
        string _password;
        string _firstlastname1;
        string _firstlastname2;
        ObservableCollection<UserModel> _users;
        #endregion
        #region Objetos
        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value);
                OnpropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string names
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

        #region Constructor
        public VMUsers(INavigation nav)
        {
            Navigation = nav;
            ExtraerApi();
        }
        #endregion

        #region Procesos
        //public async Task AddUser()
        //{
        //    await Shell.Current.GoToAsync($"//UserView");
        //}
        public void Limpiar()
        {
            names = "";
            apellidopaterno = "";
            apellidomaterno = "";
            UserName = "";
            Password = "";
            Email = "";
        }
        public async Task ExtraerApi()
        {
            Users = await UserCrud.ExtraerApi();
        }
        //public class Auth 
        //{
        //    public string Names { get; set; }
        //    public string password { get; set; }
        //    public string email { get; set; }
        //    public string firstLastName { get; set; }
        //    public string secondLastName { get; set; }
        //    public string userName { get; set; }
        //};
        //public class Responce
        //{
        //    public string Names { get; set; }
        //    public string password { get; set; }
        //    public string email { get; set; }
        //    public string firstLastName { get; set; }
        //    public string secondLastName { get; set; }
        //    public string userName { get; set; }
        //};
        public async Task AgregarUsuario()
        {
            var nuevousuario = new UserModel()
            {
                names = names,
                firstLastName = apellidopaterno,
                secondLastName = apellidomaterno,
                userName = UserName,
                email = Email,
                password = Password
            };
            var json = JsonConvert.SerializeObject(nuevousuario);
            var contentjson = new StringContent(json, Encoding.UTF8, "application/json");
            Uri requestUri = new Uri("https://jetapi.onrender.com/users");
            var cliente = new HttpClient();
            var response = await cliente.PostAsync(requestUri, contentjson);
            var resultado = await response.Content.ReadAsStringAsync();
            var respuesta = JsonConvert.DeserializeObject<UserModel>(resultado);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Nuevo Usuario", "Te dammos la bienvenida", "OK");


            }
            else
            {
                await DisplayAlert("Error", "No se pudo añadir el usuario", "OK");
            }
            names = "";
            apellidopaterno = "";
            apellidomaterno = "";
            UserName = "";
            Password = "";
            Email = "";
        }
        #endregion
    }
}
