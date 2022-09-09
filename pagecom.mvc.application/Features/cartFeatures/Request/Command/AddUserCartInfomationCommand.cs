using MediatR;
using pagecom.mvc.application.Dto.Cart;

namespace pagecom.mvc.application.Features.cartFeatures.Request.Command;

public record AddUserCartInfomationCommand(QuentityDTO QuentityInfo) : IRequest<bool>;