using pagecom.mvc.application.Contract.CartRepo;

namespace pagecom.mvc.application.Features.cartFeatures.Handler;

public class BaseCartHandler
{
    protected readonly ICartRepository _cartService;

    public BaseCartHandler(ICartRepository cartService)
    {
        _cartService = cartService;
    }
}