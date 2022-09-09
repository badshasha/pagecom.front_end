using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.BookFeatures.Handler.BookBaseHandler;
using pagecom.mvc.application.Features.BookFeatures.Request.Command;

namespace pagecom.mvc.application.Features.BookFeatures.Handler.Command;

public class BookDeleteCommandHandler : BookBaseHandlerClass , IRequestHandler<BookDeleteCommand,bool>
{
    public BookDeleteCommandHandler(IBookRepo bookservice,ISecure identity):base(bookservice,identity)
    {
    }

    public async Task<bool> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
    {
        
        var token = await this.GetToken();
        
        var response = await this._bookservice.DeleteBookAsync<ResponseDto>(request.id,token);
        return response.IsSuccess;
    }
}