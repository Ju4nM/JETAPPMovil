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
    class UserMockData
    {
        public static async Task<ObservableCollection<UserModel>> ExtraerApi()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://jetapi.onrender.com/users");
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




        /*return new ObservableCollection<UserModel>()
        {
            new UserModel()
            {
                id = "001",
                firstName = "Tomás",
                secondName = "Andrés",
                firstLastName = "Espinoza",
                secondLastName = "Trujillo",
                email = "tomas@gmail.com",
                userName = "TomasEA",
                gender = false,
                userType = true
            },
            new UserModel()
            {
                id = "002",
                firstName = "Pamela",
                secondName = "Jazmin",
                firstLastName = "Toledo",
                secondLastName = "Valenzuela",
                email = "jazmin@gmail.com",
                userName = "JazToledo",
                gender = true,
                userType = false
            },
            new UserModel()
            {
                id = "003",
                firstName = "Gilda",
                secondName = "Lorena",
                firstLastName = "Duarte",
                secondLastName = "Guerrero",
                email = "gduarte@gmail.com",
                userName = "gDuarte",
                gender = true,
                userType = false
            },
            new UserModel()
            {
                id = "004",
                firstName = "Miguel",
                secondName = "Alejandro",
                firstLastName = "Lopez",
                secondLastName = "Humo",
                email = "malopez@gmail.com",
                userName = "MaLopez",
                gender = false,
                userType = false
            },
            new UserModel()
            {
                id = "005",
                firstName = "Juan",
                secondName = "Enrique",
                firstLastName = "Martinez",
                secondLastName = "Flores",
                email = "juan@gmail.com",
                userName = "Ju4nM",
                gender = false,
                userType = false 
            },
        };*/
    }
}
