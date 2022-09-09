using MediatR;
using pagecom.mvc.application.Dto.Book;

namespace pagecom.mvc.application.Features.cartFeatures.Request.Query;

public record GetCartBookDetailsQuery(int id) : IRequest<BookDTO>;