using JET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JET.Data
{
    public class DDevices
    {
        static string url = $"{AppConfig.url}/devices";

        //peticion de temperatura limite
        public static async Task<MDevice> GetDeviceData()
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{url}/current");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var cliente = new HttpClient();
                HttpResponseMessage response = await cliente.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<MDevice>(contenido);
                    
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

        public static async Task<HttpResponseMessage> ToggleFan ()
        {
            string id = Application.Current.Properties["id"] as string;
            HttpClient client = new HttpClient();
            string dataSerialized = JsonConvert.SerializeObject(new DataToToggleFan { user = id });
            StringContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{url}/togglefan",content);

            return response;
        }
    }
}
