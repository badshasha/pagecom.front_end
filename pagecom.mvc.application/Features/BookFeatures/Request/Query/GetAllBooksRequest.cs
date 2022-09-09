using MediatR;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.SendandResive;

namespace pagecom.mvc.application.Features.BookFeatures.Request.Query;

public record GetAllBooksRequest() : IRequest<List<BookViewDto>>;