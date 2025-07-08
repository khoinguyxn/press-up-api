using Microsoft.AspNetCore.Http.HttpResults;

namespace PressUpAspireApp.Api.Modules;

public static class MenuItemModule
{
    public static void RegisterMenuItemEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/menu-items", GetAll).WithName("GetMenuItems");
    }

    private static Ok GetAll()
    {
        return TypedResults.Ok();
    }
}