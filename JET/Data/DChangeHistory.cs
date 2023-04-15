using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JET.Data
{
    class DChangeHistory
    {
        static string url = $"{AppConfig.url}/change-history";
        static HttpClient client = new HttpClient();
        public static async Task<HttpResponseMessage> FindChanges ()
        {
            HttpResponseMessage response = await client.GetAsync(url);
            return response;
        }
    }
}
