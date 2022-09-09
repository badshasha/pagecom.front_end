using pagecom.mvc.application.Dto.SendandResive;
namespace pagecom.mvc.application.Contract.RequestService;

public interface IBaseRequest
{
    ResponseDto _response { get; set; }
    Task<T> SendAsync<T>(RequestDTO requestinfo);
}