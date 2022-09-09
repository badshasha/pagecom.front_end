using MediatR;
using Newtonsoft.Json;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.cartFeatures.Request.Query;

namespace pagecom.mvc.application.Features.cartFeatures.Handler.Query;

public class GetCartBookDetailsQueryHandler :BaseCartHandler, IRequestHandler<GetCartBookDetailsQuery,BookDTO>
{
    private BookDTO bookinfo;

    public GetCartBookDetailsQueryHandler(ICartRepository cartService) : base(cartService)
    {
        bookinfo = new BookDTO();

    }
    

    public async Task<BookDTO> Handle(GetCartBookDetailsQuery request, CancellationToken cancellationToken)
    {
        string token = ContextStatic.tokenInfo;
        var response =await this._cartService.GetCartBookDetails<ResponseDto>(request.id, token);
        if (response.IsSuccess)
        {
            bookinfo = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
        }

        return bookinfo;
    }
}