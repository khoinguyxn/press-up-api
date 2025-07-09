using Microsoft.Extensions.DependencyInjection;
using PressUpAspireApp.Application.Services;
using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Domain.Services;

namespace PressUpAspireApp.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddApplicationServices();
    }

    private static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBaseService<MenuItemModel>, MenuItemService>();
    }
}