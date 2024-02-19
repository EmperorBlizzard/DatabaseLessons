using Assignment.Entites;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses {  get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
}
