using pagecom.mvc.application.Dto.Book;

namespace pagecom.mvc.application.Contract.BookRepo;

public interface IBookRepo
{
  Task<T> GetAllBooksAsync<T>(string accesstoken);
  Task<T> GetBookFromIdAsync<T>(int id,string accesstoken);
  
  Task<T> UpdateBookAsync<T>(int id, BookViewDto bookObj,string accesstoken);
  Task<T> CreateBookAsync<T>(BookViewDto bookObj,string accesstoken);
  Task<T> DeleteBookAsync<T>(int id,string accesstoken);
}