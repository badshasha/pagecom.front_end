using MediatR;
using pagecom.mvc.application.Dto.Book;

namespace pagecom.mvc.application.Features.BookFeatures.Request.Command;

public record BookCreateCommand(BookViewDto bookObj) : IRequest<BookViewDto>; // todo [why dont send bool value ]