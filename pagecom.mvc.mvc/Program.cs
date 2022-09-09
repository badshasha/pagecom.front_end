using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using pagecom.mvc.application.Extenders;
using pagecom.mvc.infastructure.Extendservice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// [extendrs]

builder.Services.InfastructorExtender(builder.Configuration);
builder.Services.ApplicationExtenderClass();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // "cookie"
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; // "oidc" // openid
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme) // optiosn and u can proviede information about cookies 
     .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options => // oide , options => // this information containing on cookies 
    {
        options.Authority = "https://localhost:7100"; // prodict api // todo change this 

        options.ClientId = "mvc_client"; // what is the client name of product api
        options.ClientSecret = "secret"; // client secret 
        options.ResponseType = "code"; // response type 

        options.Scope.Add("openid");
        options.Scope.Add("profile");

        
        options.GetClaimsFromUserInfoEndpoint = true;

        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        
        options.SaveTokens = true;

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();