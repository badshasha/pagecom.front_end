using MediatR;
using pagecom.mvc.application.Dto.Cart;

namespace pagecom.mvc.application.Features.cartFeatures.Request.Command;

public record DonecartCommand(DoneCartDTO donecartinfo) : IRequest<bool>;