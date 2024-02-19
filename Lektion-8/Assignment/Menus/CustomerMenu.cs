using Assignment.Models;
using Assignment.Services;

namespace Assignment.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();

        Console.WriteLine("Manage Customers");
        Console.WriteLine("1. View All Customers");
        Console.WriteLine("2. Add Customer");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;

            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }
    public async Task ListAllAsync()
    {
        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
        }
        Console.ReadKey();
    }

    public async Task CreateAsync()
    {

        var form = new CustomerRegistration();

        Console.Clear();

        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Write("StreetName: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
            Console.WriteLine("Created");
        else
            Console.WriteLine("Not Created");
        ;
        Console.ReadKey();
    }
}
