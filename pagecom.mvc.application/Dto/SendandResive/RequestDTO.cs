using pagecom.mvc.application.RequestMethod;

namespace pagecom.mvc.application.Dto.SendandResive;

public class RequestDTO
{
    public RequestMethodType ApiType { get; set; } = RequestMethodType.GET;
    public string RequestUrl { get; set; }
    public object? Data { get; set; } // what are we going to send 
    public string AccessToken { get; set; } = "";
}