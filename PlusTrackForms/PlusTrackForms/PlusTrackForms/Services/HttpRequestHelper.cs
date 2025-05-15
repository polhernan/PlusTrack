using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlusTrackForms.Services
{
    public static class HttpRequestHelper<RequestBody,ReturnType>
    {
        public static async Task<ReturnType> PostAsJsonAsync(string url, RequestBody requestBody)
        {
            HttpClient httpClient = new HttpClient();
            JsonSerializer serializer = new JsonSerializer();

            string json = JsonConvert.SerializeObject(requestBody);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(url, content);

            ReturnType response = JsonConvert.DeserializeObject<ReturnType>(await httpResponse.Content.ReadAsStringAsync());

            httpClient.Dispose();

            return response;
        }

        public static async Task<ReturnType> GetAsync(string url)
        {
            HttpClient httpClient = new HttpClient();

            var requestResult = await httpClient.GetAsync(url);

            var debugReturn = await requestResult.Content.ReadAsStringAsync();

            ReturnType response = JsonConvert.DeserializeObject<ReturnType>(await requestResult.Content.ReadAsStringAsync());

            httpClient.Dispose();

            return response;
        }
    }
}
