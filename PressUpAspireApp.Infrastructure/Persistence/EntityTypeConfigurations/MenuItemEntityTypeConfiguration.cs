using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PressUpAspireApp.Domain.Models;

namespace PressUpAspireApp.Infrastructure.Persistence.EntityTypeConfigurations;

public class MenuItemEntityTypeConfiguration : IEntityTypeConfiguration<MenuItemModel>
{
    public void Configure(EntityTypeBuilder<MenuItemModel> builder)
    {
        builder.HasKey(menuItem => menuItem.MenuItemId);
        builder.Property(menuItem => menuItem.MenuItemId).ValueGeneratedOnAdd();
        builder.HasOne(menuItem => menuItem.MenuCategory).WithMany(menuCategory => menuCategory.MenuItems)
            .HasForeignKey(menuItem => menuItem.MenuCategoryId);
    }
}