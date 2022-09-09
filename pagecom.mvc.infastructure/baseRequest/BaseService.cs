using System.Text;
using IdentityModel.Client;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.RequestService;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.RequestMethod;


namespace pagecom.mvc.infastructure.baseRequest;

// create message with 
    // header 
    // content 
    // method 


public class BaseService : IBaseRequest
{
    private readonly IHttpClientFactory _clientFactory;
    public ResponseDto _response { get; set; }


    public BaseService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _response = new ResponseDto();
    }
    
    
    public async Task<T> SendAsync<T>(RequestDTO requestinfo)
    {
        try
        {
            var client = _clientFactory.CreateClient("pagecom_api");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestinfo.RequestUrl);
            client.DefaultRequestHeaders.Clear();
            client.SetBearerToken(requestinfo.AccessToken);

            if (requestinfo.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestinfo.Data), Encoding.UTF8,
                    "application/json");
            }

            switch (requestinfo.ApiType)
            {
                case RequestMethodType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case RequestMethodType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case RequestMethodType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case RequestMethodType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
            }

            HttpResponseMessage responseMessage = await client.SendAsync(message);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var DesirializeInfomation = JsonConvert.DeserializeObject<T>(content);
            return DesirializeInfomation;


        }
        catch (Exception ex)
        {
            var dto = new ResponseDto()
            {
                Message = "erro",
                Error = new List<string> { ex.ToString() },
                IsSuccess = false

            };

            var res = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<T>(res);

        }




    }
}