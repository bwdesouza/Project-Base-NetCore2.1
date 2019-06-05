using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NetCore.CrossCutting
{
    public static class RestApi
    {
        public static async System.Threading.Tasks.Task<HttpResponseMessage> PostAsync(string url, object content = null, string token = null)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(content);

                using (HttpContent httpContent = new StringContent(jsonString))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    if (token != null)
                        client.DefaultRequestHeaders.Add("X-API-Token", token);

                    return await client.PostAsync(url, httpContent);
                }
            }
        }
    }
}
