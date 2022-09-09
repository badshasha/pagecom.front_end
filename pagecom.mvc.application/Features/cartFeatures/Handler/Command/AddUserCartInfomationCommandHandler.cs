using MediatR;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.Cart;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.Dto.User;
using pagecom.mvc.application.Features.cartFeatures.Request.Command;

namespace pagecom.mvc.application.Features.cartFeatures.Handler.Command;

public class AddUserCartInfomationCommandHandler : BaseCartHandler ,IRequestHandler<AddUserCartInfomationCommand,bool>
{
    public AddUserCartInfomationCommandHandler(ICartRepository cartService) : base(cartService)
    {
    }

    public async Task<bool> Handle(AddUserCartInfomationCommand request, CancellationToken cancellationToken)
    {
        // get token 
        string? token = ContextStatic.tokenInfo;
        
        var bookDetail = new bookforcartDTO() // add auto mapper 
        {
            Id = request.QuentityInfo.bookInfo.Id,
            Name = request.QuentityInfo.bookInfo.Name,
            Price = request.QuentityInfo.bookInfo.Price,
            Description = request.QuentityInfo.bookInfo.Description
        };

        var userDt = new UserDTO()  // create user information 
        {
            UserId = UserTokenInfo.UserID,
            UserName = UserTokenInfo.UserName,
            Role = UserTokenInfo.UserRole,
            Email = UserTokenInfo.userEmail,
            carts = new List<CartDTO>() // todo  fix this issues 
            {
                new CartDTO()
                {
                    Id =  0,
                    AddDateTime = DateTime.Now,
                    Delivery= true,
                    userID = "string"
                }
            }
        };
        
 
        
        // create request 
        var cartReuestInfomation = new CartRequesestInfomationDTO()
        {
            userInfo = userDt,
            bookInfo = bookDetail,
            Quenity = request.QuentityInfo.Quentity,
        };

        var respose = await this._cartService.AddUserCartProduct<ResponseDto>(cartReuestInfomation, token!);
        return respose.IsSuccess;
    }

   
}