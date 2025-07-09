using Microsoft.EntityFrameworkCore;
using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Domain.Repositories;
using PressUpAspireApp.Infrastructure.Persistence;

namespace PressUpAspireApp.Infrastructure.Repositories;

public class MenuItemRepository(PressUpApiDbContext dbContext) : IBaseRepository<MenuItemModel>
{
    public async Task<IEnumerable<MenuItemModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.MenuItems.Include(menuItem => menuItem.MenuCategory)
            .OrderBy(menuItem => menuItem.MenuItemId).ToListAsync(cancellationToken);
    }
}