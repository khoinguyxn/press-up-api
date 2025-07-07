using Microsoft.EntityFrameworkCore;

namespace PressUpAspireApp.Infrastructure.Persistence;

public class PressUpApiDbContext(
    DbContextOptions<PressUpApiDbContext> options) : DbContext(options)
{
}