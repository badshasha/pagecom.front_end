using MediatR;
using pagecom.mvc.application.Dto.Cart;

namespace pagecom.mvc.application.Features.cartFeatures.Request.Query;

public record GetUserCartproducts(int id): IRequest<List<Cart_BookDTO>> ;