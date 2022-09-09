using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Dto.User;
using pagecom.mvc.application.Features.cartFeatures.Request.Query;

namespace pagecom.mvc.application.Features.cartFeatures.Handler.Query;

public class GetUserCurrentCartQueryHandler :BaseCartHandler, IRequestHandler<GetUserCurrentCartQuery,UserDTO>
{
    private UserDTO userCart;

    public GetUserCurrentCartQueryHandler(ICartRepository cartService) : base(cartService)
    {
        userCart = new UserDTO();
    }

    public async Task<UserDTO> Handle(GetUserCurrentCartQuery request, CancellationToken cancellationToken)
    {
        string token = ContextStatic.tokenInfo;
        
        
        
        var response= await this._cartService.GetUserCurrentCart<ResponseDto>(UserTokenInfo.UserID, token);
        if (response.IsSuccess)
        {
            userCart   =  JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
        }

        return userCart;
    }
}