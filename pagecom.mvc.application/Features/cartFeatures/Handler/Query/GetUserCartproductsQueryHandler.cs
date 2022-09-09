using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.Cart;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.cartFeatures.Request.Query;

namespace pagecom.mvc.application.Features.cartFeatures.Handler.Query;


public class GetUserCartproductsQueryHandler :BaseCartHandler, IRequestHandler<GetUserCartproducts,List<Cart_BookDTO>>
{
    private List<Cart_BookDTO> userselectedProdcut;

    public GetUserCartproductsQueryHandler(ICartRepository cartService) : base(cartService)
    {
        userselectedProdcut = new List<Cart_BookDTO>();
    }

    public async Task<List<Cart_BookDTO>> Handle(GetUserCartproducts request, CancellationToken cancellationToken)
    {
        string token = ContextStatic.tokenInfo;
        var response  = await this._cartService.GetUserCartBooks<ResponseDto>(request.id, token);
        if (response.IsSuccess)
        {
            userselectedProdcut = JsonConvert.DeserializeObject<List<Cart_BookDTO>>(Convert.ToString(response.Result));
        }

        return userselectedProdcut;
    }
}