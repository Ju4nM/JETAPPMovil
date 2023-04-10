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
    class DTemperatureLimit
    {
        static string url = $"{AppConfig.url}/limit-temperatures";
        static HttpClient client = new HttpClient ();

        public static async Task<HttpResponseMessage> UpdateTemperatureLimit (double newTemperatureLimit)
        {
            string userId = Application.Current.Properties["id"] as string;
            MUpdateTL dataToSend = new MUpdateTL { limitTemperature = newTemperatureLimit, user = userId };
            string dataSerialized = JsonConvert.SerializeObject(dataToSend);
            StringContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            return response;
        }
    }
}
