using MediatR;
using pagecom.mvc.application.Dto.Book;

namespace pagecom.mvc.application.Features.BookFeatures.Request.Command;

public record BookUpdateCommand(int id, BookViewDto bookObj) : IRequest<BookViewDto>;