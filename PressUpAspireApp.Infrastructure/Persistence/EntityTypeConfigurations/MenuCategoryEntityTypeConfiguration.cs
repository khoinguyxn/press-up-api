using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PressUpAspireApp.Domain.Models;

namespace PressUpAspireApp.Infrastructure.Persistence.EntityTypeConfigurations;

public class MenuCategoryEntityTypeConfiguration: IEntityTypeConfiguration<MenuCategoryModel>
{
    public void Configure(EntityTypeBuilder<MenuCategoryModel> builder)
    {
        builder.HasKey(menuCategory => menuCategory.MenuCategoryId);
        builder.Property(menuCategory => menuCategory.MenuCategoryId).ValueGeneratedOnAdd();
    }
}