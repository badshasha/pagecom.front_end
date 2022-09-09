using MediatR;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Features.cartFeatures.Request.Command;

namespace pagecom.mvc.application.Features.cartFeatures.Handler.Command;

public class DonecartCommandHandler : BaseCartHandler, IRequestHandler<DonecartCommand,bool>
{
    

    public DonecartCommandHandler(ICartRepository cartRepository) : base(cartRepository)
    {
        
    }
    public async Task<bool> Handle(DonecartCommand request, CancellationToken cancellationToken)
    {
        
        string? token = ContextStatic.tokenInfo;
        var response = await this._cartService.DoneCart<ResponseDto>(request.donecartinfo, token!);
        return response.IsSuccess;
    }
}