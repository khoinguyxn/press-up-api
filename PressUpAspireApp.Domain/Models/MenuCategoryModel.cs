namespace PressUpAspireApp.Domain.Models;

public record MenuCategoryModel
{
    public required int MenuCategoryId { get; init; }
    public required string Name { get; init; }
    public ICollection<MenuItemModel> MenuItems { get; init; } = new List<MenuItemModel>();
}