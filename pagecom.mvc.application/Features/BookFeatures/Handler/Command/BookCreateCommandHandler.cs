using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.BookFeatures.Handler.BookBaseHandler;
using pagecom.mvc.application.Features.BookFeatures.Request.Command;

namespace pagecom.mvc.application.Features.BookFeatures.Handler.Command;

public class BookCreateCommandHandler : BookBaseHandlerClass , IRequestHandler<BookCreateCommand,BookViewDto>
{
    private BookViewDto book;
    public BookCreateCommandHandler(IBookRepo bookservice,ISecure identity):base(bookservice,identity)
    {
        book = new BookViewDto();
    }

    public async Task<BookViewDto> Handle(BookCreateCommand request, CancellationToken cancellationToken)
    {
        var token = await this.GetToken();
        
        var response = await this._bookservice.CreateBookAsync<ResponseDto>(request.bookObj,token);
        if (response.IsSuccess)
        {
            book = JsonConvert.DeserializeObject<BookViewDto>(Convert.ToString(response.Result));
        }
        return book;
    }
}