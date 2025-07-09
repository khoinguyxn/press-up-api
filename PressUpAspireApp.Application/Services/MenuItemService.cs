using FluentResults;
using Microsoft.Extensions.Logging;
using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Domain.Repositories;
using PressUpAspireApp.Domain.Services;

namespace PressUpAspireApp.Application.Services;

public class MenuItemService(IBaseRepository<MenuItemModel> menuItemRepository, ILogger<MenuItemService> logger)
    : IBaseService<MenuItemModel>
{
    public async Task<Result<IEnumerable<MenuItemModel>>> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var menuItems = await menuItemRepository.GetAllAsync(cancellationToken);

            return Result.Ok(menuItems);
        }
        catch (Exception exception)
        {
            const string errorMessage = "Unable to get all menu items!";

            logger.LogError(exception, errorMessage);
            return Result.Fail(errorMessage);
        }
    }
}