using IdentityModel.Client;

namespace pagecom.mvc.application.Contract.sercureRepo;

public interface ISecure
{
    Task<TokenResponse> GetToken();
}