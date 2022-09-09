using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Dto.User;
using pagecom.mvc.application.Features.cartFeatures.Request.Query;

namespace pagecom.mvc.application.Features.cartFeatures.Handler.Query;

public class GetUsersAllCartsRequestQueryHandler : BaseCartHandler, IRequestHandler<GetUsersAllCartsRequest,UserDTO>
{
    private UserDTO userCart;


    public GetUsersAllCartsRequestQueryHandler(ICartRepository cartService) : base(cartService)
    {
         userCart = new UserDTO();
    }
    
    
    public async Task<UserDTO> Handle(GetUsersAllCartsRequest request, CancellationToken cancellationToken)
    {
        var token = ContextStatic.tokenInfo;
        var response = await this._cartService.GetUsersAllCarts<ResponseDto>(UserTokenInfo.UserID,token);
        if (response.IsSuccess)
        {
            userCart = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
        }

        return userCart;
    }


}