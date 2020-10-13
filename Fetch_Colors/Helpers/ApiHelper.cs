using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Web;

namespace Fetch_Colors.Helpers
{
    public class ApiHelper : IApiHelper
    {
        public async Task<T> Fetch<T>(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var response = await content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<T>(response);
                    }
                }
            }
        }
    }
}