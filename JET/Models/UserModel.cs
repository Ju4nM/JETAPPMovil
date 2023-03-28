using System;
using System.Collections.Generic;
using System.Text;
using JET.ViewModel;
using Newtonsoft.Json;

namespace JET.Models
{
    public class UserModel: BaseViewModel
    {
        // Necesitan actualizacion
        public string names { get; set; }
        public string firstLastName { get; set; }
        public string userName { get; set; }
        [JsonProperty("_id")]
        public string id { get; set; }
        public string password { get; set; }
        // No necesitan actualizarse en la vista
        public string SecondName { get; set; }
        public string secondLastName { get; set; }
        public string email { get; set; }
        public bool userType { get; set; }
        public bool Gender { get; set; }
    }
}
