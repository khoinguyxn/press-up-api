using Microsoft.EntityFrameworkCore;
using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Infrastructure.Persistence.EntityTypeConfigurations;

namespace PressUpAspireApp.Infrastructure.Persistence;

public class PressUpApiDbContext(
    DbContextOptions<PressUpApiDbContext> options) : DbContext(options)
{
    public DbSet<MenuItemModel> MenuItems { get; init; }
    public DbSet<MenuCategoryModel> MenuCategories { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new MenuItemEntityTypeConfiguration().Configure(modelBuilder.Entity<MenuItemModel>());
        new MenuCategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<MenuCategoryModel>());
    }
}