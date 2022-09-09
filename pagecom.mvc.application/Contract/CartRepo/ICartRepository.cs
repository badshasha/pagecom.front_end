using pagecom.mvc.application.Dto.Cart;

namespace pagecom.mvc.application.Contract.CartRepo;

public interface ICartRepository
{
    
    // todo get request only u need to add post request 
    // get request 
    Task<T> GetUsersAllCarts<T>(string id,string accessToken); // get users all cart [history]
    Task<T> GetUserCurrentCart<T>(string id,string accessToken); // get user current using cart 
    Task<T> GetUserCartBooks<T>(int id,string accessToken); // all books include in the cart 
    Task<T> GetCartBookDetails<T>(int id,string accessToken); // get details about the books --> information comming form pagecom.chart database
    
    
    // post request 
    // add user
    Task<T> AddUserCartProduct<T>(CartRequesestInfomationDTO info, string accessToken);
    Task<T> ContinueShipping<T>(int cartId);

    Task<T> DoneCart<T>(DoneCartDTO info,string accesstoken);

}