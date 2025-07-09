using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Infrastructure.Repositories;

namespace PressUpAspireApp.Infrastructure.Tests.Repositories;

public sealed class MenuItemRepositoryTests(DatabaseFixture fixture)
    : IClassFixture<DatabaseFixture>
{
    private readonly MenuItemRepository _menuItemRepository = new(fixture.DbContext);
    private readonly CancellationToken _cancellationToken = CancellationToken.None;

    [Fact]
    public async Task ShouldReturnMenuItems_WhenSuccessful()
    {
        // Arrange
        var menuCategory = new MenuCategoryModel
        {
            MenuCategoryId = 1,
            Name = "Test"
        };

        var menuItems = new List<MenuItemModel>
        {
            new()
            {
                MenuItemId = 2,
                Price = 1,
                Name = "Iced long black",
                MenuCategoryId = menuCategory.MenuCategoryId,
                MenuCategory = menuCategory
            },
            new()
            {
                MenuItemId = 1,
                Price = 1,
                Name = "Latte",
                MenuCategoryId = menuCategory.MenuCategoryId,
                MenuCategory = menuCategory
            }
        };
        
        fixture.DbContext.AddRange(menuItems);
        await fixture.DbContext.SaveChangesAsync(_cancellationToken);
        
        // Act
        var result = (await _menuItemRepository.GetAllAsync(_cancellationToken)).Reverse();
        
        // Assert
        Assert.Equal(result, menuItems);
    }
}