using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.SendandResive;
using pagecom.mvc.application.RequestMethod;
using pagecom.mvc.infastructure.baseRequest;
using pagecom.mvc.infastructure.webAddressInfo;

namespace pagecom.mvc.infastructure.Repository;

public class BookService : BaseService, IBookRepo
{
    public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<T> GetAllBooksAsync<T>(string accesstoken)
    {
        return await this.SendAsync<T>(new RequestDTO()
        {   
            ApiType = RequestMethodType.GET,
            RequestUrl = webAddressInfoClass.PagecomApiBase + "api/book",
            AccessToken = accesstoken
        });
    }

    public async Task<T> GetBookFromIdAsync<T>(int id,string accesstoken)
    {
        return await this.SendAsync<T>(new RequestDTO()
        {
            ApiType = RequestMethodType.GET,
            RequestUrl = webAddressInfoClass.PagecomApiBase + "api/book/"+ id ,
            AccessToken = accesstoken
        });
    }

    public async Task<T> UpdateBookAsync<T>(int id, BookViewDto bookobj,string accesstoken)
    {
        return await this.SendAsync<T>(new RequestDTO()
        {
            ApiType = RequestMethodType.PUT,
            RequestUrl = webAddressInfoClass.PagecomApiBase + "api/Book/" + id ,
            Data = bookobj,
            AccessToken = accesstoken
        });
    }

    public async Task<T> CreateBookAsync<T>(BookViewDto bookObj,string accesstoken)
    {
        return await this.SendAsync<T>(new RequestDTO()
        {
            ApiType = RequestMethodType.POST,
            RequestUrl = webAddressInfoClass.PagecomApiBase + "api/book" ,
            Data = bookObj,
            AccessToken = accesstoken
        });
    }

    public async Task<T> DeleteBookAsync<T>(int id,string accesstoken)
    {
        return await this.SendAsync<T>(new RequestDTO()
        {
            ApiType = RequestMethodType.DELETE,
            RequestUrl = webAddressInfoClass.PagecomApiBase + "api/book/"+ id,
            AccessToken =accesstoken
        });
    }

  
}