using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace demoPoC.RestClients
{
    public class RestClient<T>
    {
        public async Task<List<T>> GetAsync(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(uri);
                var ret =  JsonConvert.DeserializeObject<List<T>>(json);
                return ret;

            }
        }

        public async Task<bool> PostAsync(T t, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(t);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(uri, httpContent);
                return result.IsSuccessStatusCode;

            }
        }

        public async Task<bool> PutAsync(int id, T t, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(t);

                HttpContent httpContent = new StringContent(json);

                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await httpClient.PutAsync(uri + id, httpContent);

                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteAsync(int id, T t, string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(uri + id);
                return response.IsSuccessStatusCode;

            }
        }
    }
}
