using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using pagecom.mvc.application.Contract.BookRepo;
using pagecom.mvc.infastructure.Repository;
using pagecom.mvc.infastructure.webAddressInfo;
using IdentityModel.Client;
using pagecom.mvc.application.Contract.CartRepo;
using pagecom.mvc.application.Contract.sercureRepo;
using pagecom.mvc.infastructure.Repository.Cart_service;

namespace pagecom.mvc.infastructure.Extendservice;

public static class InfastructureExtendService
{
    
    public static IServiceCollection InfastructorExtender(this IServiceCollection service,IConfiguration configuration )
    {
        var basewebAddress = configuration.GetSection("api"); // get connection informaition
        webAddressInfoClass.PagecomApiBase =basewebAddress["pagecom"]; // get api // todo change need [docker] 
        webAddressInfoClass.PagecomCart = basewebAddress["cart"]; // get cart api
        service.AddHttpClient("pagecom_api");


        // identity server configuration 
        var identityInfomation = configuration.GetSection("secure");
        SecureInformation.address = identityInfomation["ADDRESS"];
        SecureInformation.client_id = identityInfomation["CLIENT_ID"];
        SecureInformation.secret = identityInfomation["CLIENT_SECRET"];
        SecureInformation.scope = identityInfomation["SCOPE"];

        // todo i dont know
        service.AddHttpClient("secure");

        // book repo
        service.AddScoped<IBookRepo, BookService>();
        //secure
        service.AddScoped<ISecure, SecureService>();
        
        // cart 
        service.AddScoped<ICartRepository, CartService>();
        
        return service;
    }
}