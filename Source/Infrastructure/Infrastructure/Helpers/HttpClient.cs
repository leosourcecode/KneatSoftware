using System;
using net = System.Net.Http;
using System.Threading.Tasks;
using Application.Helpers;

namespace Infrastructure.Helpers
{
    public class HttpClient : IHttpClient
    {
        private static net.HttpClient _client;
        public HttpClient()
        {
            _client = new net.HttpClient(new net.HttpClientHandler()
            {
                UseDefaultCredentials = true
            });
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Call API using GET
        /// </summary>
        /// <param name="url">Url to be used to call the API</param>
        /// <returns>The Content as string</returns>
        public async Task<string> GetAsync(string url)
        {
            return await CreateRequest(url, net.HttpMethod.Get);
        }

        private async Task<string> CreateRequest(string url, net.HttpMethod method)
        {
            using (var request = new net.HttpRequestMessage(method, Uri.EscapeUriString(url)))
            {
                return await GetResult(request);
            }
        }

        private async Task<string> GetResult(net.HttpRequestMessage msg)
        {
            using (net.HttpResponseMessage response = await _client.SendAsync(msg))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error to call API. Content {response.Content?.ReadAsStringAsync().Result} - Response: {response} - Request: {msg}.");
                }
                else
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
