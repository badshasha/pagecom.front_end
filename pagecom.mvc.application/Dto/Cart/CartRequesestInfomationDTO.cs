using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.User;

namespace pagecom.mvc.application.Dto.Cart;

public class CartRequesestInfomationDTO
{
    public UserDTO userInfo { get; set; }
    public bookforcartDTO bookInfo { get; set; }

    public int Quenity { get; set; } = 1;    
}