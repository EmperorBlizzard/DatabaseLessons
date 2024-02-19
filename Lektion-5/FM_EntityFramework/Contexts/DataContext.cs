using FM_EntityFramework.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace FM_EntityFramework.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}
