using System.Text.Json.Serialization;
using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.BookFeatures.Handler.BookBaseHandler;
using pagecom.mvc.application.Features.BookFeatures.Request.Query;


namespace pagecom.mvc.application.Features.BookFeatures.Handler.Query;

public class GetAllBooksRequestHandler : BookBaseHandlerClass, IRequestHandler<GetAllBooksRequest,List<BookViewDto>>
{
    
    public List<BookViewDto> BookList;

    public GetAllBooksRequestHandler(IBookRepo bookservice,ISecure identity):base(bookservice,identity)
    {
        BookList = new();
    }


    public async Task<List<BookViewDto>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {

        var token = await this.GetToken();
        
        
        var response = await this._bookservice.GetAllBooksAsync<ResponseDto>(token);
        if (response.IsSuccess)
        {
            BookList = JsonConvert.DeserializeObject<List<BookViewDto>>(Convert.ToString(response.Result));
        }
        return BookList;
    }
}