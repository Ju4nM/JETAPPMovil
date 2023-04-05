using JET.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JET.Data
{
    public class UserCrud 
    {
        //url del servidor web de nuestra api
        static string url = "https://jetapi.onrender.com";
        //peticion de usuarios
        public static async Task<ObservableCollection<UserModel>> ExtraerApi()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{url}/users");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var cliente = new HttpClient();
                HttpResponseMessage response = await cliente.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(contenido);

                    return resultado;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
