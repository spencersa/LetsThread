using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LetsThread
{
    public class HttpClientService
    {
        private HttpClient _client;

        public HttpClientService()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<string>> GetValues()
        {
            try
            {
                var response = await _client.GetAsync("api/values");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<IEnumerable<string>>();
            }
            catch (HttpRequestException ex)
            {
                return new List<string>
                {
                    ex.ToString()
                };
            }
        }
    }
}
