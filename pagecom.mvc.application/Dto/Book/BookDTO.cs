using pagecom.mvc.application.Dto.Cart;

namespace pagecom.mvc.application.Dto.Book;

public class BookDTO
{
    public int Id { get; set; }
    
    public String Name { get; set; }
    public String Description { get; set; }
    public Double Price { get; set; }
    
    // relationship
    public List<Cart_BookDTO> CartBooks { get; set; }  // todo can be some error 
    
}