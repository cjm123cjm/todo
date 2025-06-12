using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ToDoApp.WPF.HttpClients
{
    /// <summary>
    /// 调用api工具类
    /// </summary>
    public class HttpRestClient
    {
        private RestClient _client;
        private string baseUrl = "http://localhost:5006/api";

        public HttpRestClient()
        {
            _client = new RestClient();
        }

        public async Task<ResponseDto> Execute(ApiRequest apiRequest)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.Method = apiRequest.Method;
            restRequest.AddHeader("Content-Type", apiRequest.ContentType);

            if (apiRequest.Parameters != null)
            {
                restRequest.AddParameter("param", JsonConvert.SerializeObject(apiRequest.Parameters), ParameterType.RequestBody);
            }

            _client.BaseUrl = new Uri(baseUrl + apiRequest.Route);

            var response = await _client.ExecuteAsync(restRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<ResponseDto>(response.Content)!;
            }
            else
            {
                return new ResponseDto { IsSuccess = false, Message = "服务器异常" };
            }
        }
    }
}
