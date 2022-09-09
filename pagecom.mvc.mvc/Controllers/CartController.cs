using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using pagecom.mvc.application.Dto;
using pagecom.mvc.application.Dto.Book;
using pagecom.mvc.application.Dto.Cart;
using pagecom.mvc.application.Dto.User;
using pagecom.mvc.application.Features.BookFeatures.Request.Query;
using pagecom.mvc.application.Features.cartFeatures.Request.Command;
using pagecom.mvc.application.Features.cartFeatures.Request.Query;

namespace pagecom.mvc.mvc.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    //  var tenantIdClaim = jwt_token.Claims.SingleOrDefault(c => c.Type == "TenantId");
    
    // GET
    public async Task<IActionResult> Index()
    {
        
        
        // var token =ContextStatic.tokenInfo;
        // if (token == null)
        // {
        //     token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
        // }
        //
        // var handler = new JwtSecurityTokenHandler();
        // var jwt = handler.ReadJwtToken(token);
        // var namefinder = jwt.Claims.FirstOrDefault(c => c.Type == "name");
        // var name = namefinder.Value;
        // Console.WriteLine(namefinder);
        await this.GetInformationFromToken();
        return View();
    }

    private async Task GetInformationFromToken()
    {
        if (UserTokenInfo.UserID == null)
        {
            var token =ContextStatic.tokenInfo;
            if (token == null)
            {
                token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            }

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            UserTokenInfo.UserID = jwt.Claims.FirstOrDefault(c => c.Type == "sub")!.Value;
            UserTokenInfo.UserName = jwt.Claims.FirstOrDefault(c => c.Type == "name")!.Value;
            UserTokenInfo.userEmail = jwt.Claims.FirstOrDefault(c => c.Type == "name")!.Value;
            UserTokenInfo.UserRole = jwt.Claims.FirstOrDefault(c => c.Type == "role")!.Value;
            return;
        }

        return;


    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProductToCart(ProdcutInfowithQuentity quentityinfo)
    {
    
        // token informatino gathering 
        await this.GetInformationFromToken();
        
        var value = new QuentityDTO()
        {
            Quentity = quentityinfo.QuentityDto.Quentity,
            bookInfo = await this._mediator.Send(new GetBookFromIdRequest(quentityinfo.QuentityDto.ProdcutId)),
            ProdcutId = quentityinfo.QuentityDto.ProdcutId,
        };

       // var bookinfo = await this._mediator.Send(new GetBookFromIdRequest(quentityinfo.QuentityDto.ProdcutId));
        
        var success_or_false =await this._mediator.Send(new AddUserCartInfomationCommand(value));
        if (success_or_false)
        {
            return RedirectToAction("GetCurrentCart","Cart",new{id = UserTokenInfo.UserID });
        }

        return RedirectToAction("index","Home");
    }

    public async Task<IActionResult> DoneCart(int id)
    {
        DoneCartDTO cartInformatino = new()
        {
            userId = UserTokenInfo.UserID!,
            CartId = id,
            Email = UserTokenInfo.userEmail,
        };

        return View(cartInformatino);
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DoneCartPost(DoneCartDTO cartInfo)
    { 
        // after sending get request 
        // send success view page to download product
        var details = await this._mediator.Send(new DonecartCommand(cartInfo));
        return View();
    }

    public async Task<IActionResult> GetCurrentCart()
    {
        await this.GetInformationFromToken();
        var cartDetails = await this._mediator.Send(new GetUserCurrentCartQuery());
        return View(cartDetails);
    }

    
    public async Task<IActionResult> GetCartProduct(int id)
    {
        await this.GetInformationFromToken();
        var products = await this._mediator.Send(new GetUserCartproducts(id));
        return View(products);
    }

    public async Task<IActionResult> GetHistory()
    {
        var carts = await this._mediator.Send(new GetUsersAllCartsRequest());
        return View(carts);
    }

    public async Task<IActionResult> GetProductInfomation(int id)
    {
        var book = await this._mediator.Send(new GetCartBookDetailsQuery(id));
        return View(book);
    }




}