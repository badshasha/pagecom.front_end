using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.BookFeatures.Handler.BookBaseHandler;
using pagecom.mvc.application.Features.BookFeatures.Request.Query;

namespace pagecom.mvc.application.Features.BookFeatures.Handler.Query;

public class GetBookFromIdRequestHandler : BookBaseHandlerClass, IRequestHandler<GetBookFromIdRequest,BookViewDto>
{
    
    public GetBookFromIdRequestHandler(IBookRepo bookservice,ISecure identity):base(bookservice,identity)
    {
    }
    
    public async Task<BookViewDto> Handle(GetBookFromIdRequest request, CancellationToken cancellationToken)
    {
        
        var token = await this.GetToken();
        
        
        BookViewDto book = new();
        var response = await this._bookservice.GetBookFromIdAsync<ResponseDto>(request.id,token);
        if (response.IsSuccess)
        {
            book = JsonConvert.DeserializeObject<BookViewDto>(Convert.ToString(response.Result));
        }
        return book;
    }

 
}