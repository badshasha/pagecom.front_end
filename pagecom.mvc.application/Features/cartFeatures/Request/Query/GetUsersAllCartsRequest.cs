using MediatR;
using pagecom.mvc.application.Dto.User;

namespace pagecom.mvc.application.Features.cartFeatures.Request.Query;

public record GetUsersAllCartsRequest():IRequest<UserDTO>;