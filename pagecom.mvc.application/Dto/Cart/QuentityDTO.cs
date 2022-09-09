using pagecom.mvc.application.Dto.Book;

namespace pagecom.mvc.application.Dto.Cart;

public class QuentityDTO
{
    public int ProdcutId { get; set; }
    public int Quentity { get; set; }

    public BookViewDto bookInfo { get; set; }
}