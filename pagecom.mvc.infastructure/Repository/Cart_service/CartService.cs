using System.ComponentModel.Design;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto.Cart;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Dto.User;
using pagecom.mvc.application.RequestMethod;
using pagecom.mvc.infastructure.baseRequest;
using pagecom.mvc.infastructure.webAddressInfo;

namespace pagecom.mvc.infastructure.Repository.Cart_service;

public class CartService : BaseService, ICartRepository
{
    // ctor
    public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }
    
     // get request only 
    public async Task<T> GetUsersAllCarts<T>(string id,string accessToken) // url need to change 
    {
        var request =new RequestDTO()
        {
            ApiType = RequestMethodType.GET,
            RequestUrl = webAddressInfoClass.PagecomCart + "api/cart/allcart/" + id,
            AccessToken = accessToken
        };
        return await this.SendAsync<T>(request);
    }

    public async Task<T> GetUserCurrentCart<T>(string id, string accessToken) // url need to change 
    {
        
        var request =new RequestDTO()
        {
            ApiType = RequestMethodType.GET,
            RequestUrl = webAddressInfoClass.PagecomCart + "api/cart/currentcart/" + id,
            AccessToken = accessToken
        };
        return await this.SendAsync<T>(request);
    }

    public async Task<T> GetUserCartBooks<T>(int id, string accessToken)
    {
        
        var request =new RequestDTO()
        {
            ApiType = RequestMethodType.GET,
            RequestUrl = webAddressInfoClass.PagecomCart + "api/cart/getbooks/"+id,
            AccessToken = accessToken
        };
        return await this.SendAsync<T>(request);
    }

    public async Task<T> GetCartBookDetails<T>(int id, string accessToken)
    {
        var request =new RequestDTO()
        {
            ApiType = RequestMethodType.GET,
            RequestUrl = webAddressInfoClass.PagecomCart + "api/cart/getbookinfo/"+id,
            AccessToken = accessToken
        };
        return await this.SendAsync<T>(request);
    }

    
    // post request 

    public async Task<T> AddUserCartProduct<T>(CartRequesestInfomationDTO info, string accessToken)
    {
        var request =new RequestDTO()
        {
            ApiType = RequestMethodType.POST,
            RequestUrl = webAddressInfoClass.PagecomCart + "api/cart",
            Data = info,
            AccessToken = accessToken
        };
        return await this.SendAsync<T>(request);
    }

    
    public Task<T> ContinueShipping<T>(int id) // done handler 
    {
  
        throw new NotImplementedException();
        
    }

    public async Task<T> DoneCart<T>(DoneCartDTO info,string accesstoken)
    {
        var request =new RequestDTO()
        {
            ApiType = RequestMethodType.POST,
            RequestUrl = webAddressInfoClass.PagecomCart + "api/cart/done",
            Data = info,
            AccessToken = accesstoken
        };
        return await this.SendAsync<T>(request);
    }
}