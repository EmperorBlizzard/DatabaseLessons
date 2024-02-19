using Microsoft.Extensions.DependencyInjection;

namespace FM.Menus;

internal class MainMenu
{
    private readonly ProductsMenu _productsMenu;
    private readonly CustomersMenu _customersMenu;
    private readonly OrdersMenu _ordersMenu;

    public MainMenu(ProductsMenu productsMenu, CustomersMenu customersMenu, OrdersMenu ordersMenu)
    {
        _productsMenu = productsMenu;
        _customersMenu = customersMenu;
        _ordersMenu = ordersMenu;
    }

    public async Task ShowAsync()
    {
        var exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("1. GO to Products");
            Console.WriteLine("2. GO to Customers");
            Console.WriteLine("3. GO to Orders");
            Console.WriteLine("0. Turn off");
            Console.Write("Choose one option: ");
            var goToOption = Console.ReadLine();

            switch (goToOption)
            {
                case "1":
                    await _productsMenu.ShowAsync();
                    break;
                case "2":
                    await _customersMenu.ShowAsync();
                    break;
                case "3":
                    await _ordersMenu.ShowAsync();
                    break;

                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Not valid option");
                    Console.ReadKey();
                    break;
            }

        } while (exit);
    }
}
