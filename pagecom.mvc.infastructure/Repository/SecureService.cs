using pagecom.mvc.application.Contract.sercureRepo;
using IdentityModel.Client;
using pagecom.mvc.application.Dto;
using pagecom.mvc.infastructure.webAddressInfo;

namespace pagecom.mvc.infastructure.Repository;

public class SecureService : ISecure
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _client;
    

    public SecureService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _client = _clientFactory.CreateClient("secure");
    }


    public ClientCredentialsTokenRequest CreateToken()
    {
        
        var apiClientCredintials = new ClientCredentialsTokenRequest()
        {
            Address = SecureInformation.address,
            ClientId = SecureInformation.client_id,
            ClientSecret = SecureInformation.secret,
            Scope = SecureInformation.scope
        };
        return apiClientCredintials;
    }

    public async Task<TokenResponse> GetToken()
    {
        var clientCredential = this.CreateToken();
        var response =await this._client.RequestClientCredentialsTokenAsync(clientCredential);
        if (response.IsError)
        {
            return null;
        }
        
        return response;

      
    }
}