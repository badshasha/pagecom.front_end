using pagecom.mvc.application.Dto.Cart;

namespace pagecom.mvc.application.Dto.User;

public class UserDTO
{
    public string UserId { get; set; }
    
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public List<CartDTO> carts { get; set; }
}