using Assignment.Models;
using Assignment.Services;

namespace Assignment.Menus;

internal class ProductMenu
{
    private readonly ProductService _productService;

    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }

    public async Task ManageProducts()
    {
        Console.Clear();

        Console.WriteLine("Manage Products");
        Console.WriteLine("1. View All Products");
        Console.WriteLine("2. Add Product");
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
        var products = await _productService.GetAllAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} {product.Category.CategoryName}");
            Console.WriteLine()
        }
        Console.ReadKey();
    }

    public async Task CreateAsync()
    {

        var form = new ProductRegistration();

        Console.Clear();

        Console.Write("Product Name: ");
        form.ProductName = Console.ReadLine()!;

        Console.Write("Description:  ");
        form.ProductDescription = Console.ReadLine()!;

        Console.Write("Price: ");
        form.ProuctPrice = decimal.Parse(Console.ReadLine()!);

        Console.Write("Pricing Unit (st/pkt/tim): ");
        form.PricingUnit = Console.ReadLine()!;

        Console.Write("Category: ");
        form.ProductCategory = Console.ReadLine()!;

        var result = await _productService.CreateCustomerAsync(form);
        if (result)
            Console.WriteLine("Created");
        else
            Console.WriteLine("Not Created");
        ;
        Console.ReadKey();
    }
}
