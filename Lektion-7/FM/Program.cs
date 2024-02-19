using FM.Menus;
using FM.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FM;

internal class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<MainMenu>();
        services.AddSingleton<ProductsMenu>();
        services.AddSingleton<CustomersMenu>();
        services.AddSingleton<OrdersMenu>();
        services.AddSingleton<ProductService>();

        using var sp = services.BuildServiceProvider();
        
        var mainMenu = sp.GetRequiredService<MainMenu>();
        await mainMenu.ShowAsync();

    }
}