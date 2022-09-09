using IdentityModel.Client;
using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.application.Dto;

namespace pagecom.mvc.application.Features.BookFeatures.Handler.BookBaseHandler;

public abstract class BookBaseHandlerClass
{
    protected readonly IBookRepo _bookservice;
    private readonly ISecure _identity;

    public BookBaseHandlerClass(IBookRepo bookservice,ISecure identity)
    {
        _bookservice = bookservice;
        _identity = identity;
    }

    public async Task<string> GetToken()
    {
        // return _identity.GetToken();
        return ContextStatic.tokenInfo;
    }

    // public async Task<string> GetStaticToken()
    // {
    //     return ContextStatic.tokenInfo;
    // }
}