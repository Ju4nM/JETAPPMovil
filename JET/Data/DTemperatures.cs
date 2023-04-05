using JET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JET.Data
{
    public class DTemperatures
    {
        static string url = "https://jetapi.onrender.com";

        //peticion para temperatura actual
        public static async Task<Temperatures> ExtraerTemActual()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{url}/temperatures/last");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var cliente = new HttpClient();
                HttpResponseMessage response = await cliente.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Temperatures>(contenido);

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

        //peticion temperatura historial
        public static async Task<ObservableCollection<Temperatures>> ExtraerTemperatura()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{url}/temperatures");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var cliente = new HttpClient();
                HttpResponseMessage response = await cliente.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<ObservableCollection<Temperatures>>(contenido);

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
        //peticion de temperatura limite
        public static async Task<LimitTemperatures> ExtraerTemLimite()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{url}/devices/current");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var cliente = new HttpClient();
                HttpResponseMessage response = await cliente.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<LimitTemperatures>(contenido);
                    
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
