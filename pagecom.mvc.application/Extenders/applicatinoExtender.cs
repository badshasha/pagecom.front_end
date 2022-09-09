using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace pagecom.mvc.application.Extenders;

public static class applicatinoExtender
{
    public static IServiceCollection ApplicationExtenderClass(this IServiceCollection service)
    {
        service.AddMediatR(Assembly.GetExecutingAssembly());
        return service;
    }

}