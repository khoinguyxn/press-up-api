using Carter;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PressUpAspireApp.Api.Modules;

public class MenuItemModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/menu-items", GetAll).WithName("GetMenuItems");
    }

    private static Ok GetAll()
    {
        return TypedResults.Ok();
    }
}