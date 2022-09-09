using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace pagecom.mvc.mvc.Controllers;

public class SecureController : Controller
{
    // GET
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }

    public async Task Logout()
    {
        // both very important 
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // sign out from the cookies 
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);   // sign out from the openid server
    }
}