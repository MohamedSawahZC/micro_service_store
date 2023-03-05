using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Mango.Web.Services
{
    public class BaseServiceImpl : IBaseService
    {
        public ResponseDto responseDto { get ; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseServiceImpl(IHttpClientFactory httpClientFactory)
        {
            responseDto= new ResponseDto();
            httpClient = httpClientFactory;
        }
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data!= null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch(apiRequest.apiType)
                {
                    case SSD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SSD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case SSD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SSD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method=HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch(Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>
                    {
                        Convert.ToString(ex.Message)
                    },
                    IsSuccess = false,

                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
