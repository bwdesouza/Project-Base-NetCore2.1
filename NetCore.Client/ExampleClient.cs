using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

using NetCore.CrossCutting;

namespace NetCore.Client
{
    public class ExampleClient
    {
        //    private string Token { get; set; }
        //    private string ApiUrl { get; set; }
        //    private const string ListByIdLivroRoute = "v1/gif/{0}";

        //    public ExampleClient(string token)
        //    {
        //        ApiUrl = ConnectionStrings.EditorDigitalApiURL;
        //        Token = token;
        //    }

        //    public async Task<List<GifViewModel>> ListByIdLivro(int idLivro)
        //    {
        //        var lst = new List<GifViewModel>();
        //        using (var client = new HttpClient())
        //        {
        //            try
        //            {
        //                client.BaseAddress = new Uri(ApiUrl);
        //                client.DefaultRequestHeaders.Accept.Clear();
        //                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //                // New code:
        //                HttpResponseMessage response = await client.GetAsync(string.Format(ListByIdLivroRoute, idLivro));
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var stringJson = await response.Content.ReadAsStringAsync();
        //                    var obj = JsonConvert.DeserializeObject<RootObjectListGif>(stringJson);
        //                    //var obj = JsonUtil.JsonToObject<RootObjectListGif>(stringJson);
        //                    lst = obj.data;
        //                }
        //                return  lst;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //}

        //public class RootObjectListGif
        //{
        //    public List<GifViewModel> data { get; set; }
        //}

        //public class RootObjectSingleGif
        //{
        //    public GifViewModel data { get; set; }
        //}
    }
}
