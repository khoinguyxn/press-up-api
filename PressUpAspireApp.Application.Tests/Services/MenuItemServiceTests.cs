using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using PressUpAspireApp.Application.Services;
using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Domain.Repositories;

namespace PressUpAspireApp.Application.Tests.Services;

public class MenuItemServiceTests
{
    private readonly MenuItemService _menuItemService;
    private readonly Mock<IBaseRepository<MenuItemModel>> _mockMenuItemRepository = new();
    private readonly CancellationToken _cancellationToken = CancellationToken.None;

    public MenuItemServiceTests()
    {
        var logger = new NullLogger<MenuItemService>();

        _menuItemService = new MenuItemService(_mockMenuItemRepository.Object, logger);
    }

    [Fact]
    public async Task ShouldReturnMenuItems_WhenOk()
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

        _mockMenuItemRepository.Setup(repo => repo.GetAllAsync(_cancellationToken)).ReturnsAsync(menuItems);

        // Act
        var result = await _menuItemService.GetAllAsync(_cancellationToken);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(menuItems);

        _mockMenuItemRepository.Verify(repo => repo.GetAllAsync(_cancellationToken), Times.Once);
    }

    [Fact]
    public async Task ShouldReturnFailedReasons_WhenFailed()
    {
        // Arrange
        const string errorMessage = "Unable to get all menu items!";
        var exception = new OperationCanceledException();

        _mockMenuItemRepository.Setup(repo => repo.GetAllAsync(_cancellationToken)).ThrowsAsync(exception);

        // Act
        var result = await _menuItemService.GetAllAsync(_cancellationToken);

        // Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().NotBeEmpty();
        result.Errors[0].Message.Should().Be(errorMessage);

        _mockMenuItemRepository.Verify(repo => repo.GetAllAsync(_cancellationToken), Times.Once);
    }
}