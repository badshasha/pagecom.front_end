using MediatR;

namespace pagecom.mvc.application.Features.BookFeatures.Request.Command;

public record BookDeleteCommand(int id) : IRequest<bool>;