namespace PressUpAspireApp.Domain.Models;

public record MenuItemModel
{
    public required int MenuItemId { get; init; }
    public required float Price { get; init; }
    public required string Name { get; init; }
    public required int MenuCategoryId { get; init; }
    public required MenuCategoryModel MenuCategory { get; init; }
}