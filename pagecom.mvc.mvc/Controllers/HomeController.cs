using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using pagecom.mvc.application.Dto;
using pagecom.mvc.mvc.Models;
using MediatR;
using pagecom.mvc.application.Dto.Cart;
using pagecom.mvc.application.Features.BookFeatures.Request.Query;

namespace pagecom.mvc.mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger,IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    private async Task createToken() // not in use
    {
        //var value = await HttpContext.GetTokenAsync("access_token");
        if (ContextStatic.tokenInfo == null)
        {
            var value =await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            ContextStatic.tokenInfo = value;
        }

    }

    public async Task<IActionResult> Index()
    {
        var booklist = await this._mediator.Send(new GetAllBooksRequest());
        return View(booklist);
    }


    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var book = await this._mediator.Send(new GetBookFromIdRequest(id));
        var value = new ProdcutInfowithQuentity()
        {
            BookViewDto = book,
            QuentityDto = new QuentityDTO()
            {
                ProdcutId = book.Id,
                Quentity = 1
            }
        };
        return View(value);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}