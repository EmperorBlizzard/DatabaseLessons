using FM_EntityFrameworkCore.Contexts;
using FM_EntityFrameworkCore.Repositories;
using FM_EntityFrameworkCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FM_EntityFrameworkCore;

internal class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Database\Lessons\Lektion-6\FM_EntityFrameworkCore\Contexts\fm_database.mdf;Integrated Security=True;Connect Timeout=30"));
        services.AddScoped<CustomerRepository>();
        services.AddScoped<CustomerTypeRepository>();
        services.AddScoped<CustomerTypeService>();

        using var sp = services.BuildServiceProvider();

        var customerTypeService = sp.GetRequiredService<MenuService>();
        await customerTypeService!.CreatCustomerTypeMenuAsync();
    }
}