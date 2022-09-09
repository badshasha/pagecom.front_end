namespace pagecom.mvc.application.Dto.Cart;

public class Cart_BookDTO
{
    // public int Id { get; set; }
    // public int CartId { get; set; }
    // public int BookId { get; set; }
    // public int? Quentity { get; set; } = null;
    
    
    
        
    public int Id { get; set; }
    public DateTime AddDateTime { get; set; } = DateTime.Now;
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    
    public int CartId { get; set; }
    

    public int BookId { get; set; }
    public string BookName { get; set; }

    public int? Quentity { get; set; } 
}