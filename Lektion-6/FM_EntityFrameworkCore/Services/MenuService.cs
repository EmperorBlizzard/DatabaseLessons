using FM_EntityFrameworkCore.Entities;

namespace FM_EntityFrameworkCore.Services;

internal class MenuService
{
    private readonly CustomerTypeService customerTypeService;

    public MenuService(CustomerTypeService customerTypeService)
    {
        this.customerTypeService = customerTypeService;
    }

    public async Task CreatCustomerTypeMenuAsync()
    {
        var customerTypeEntity = new CustomerTypeEntity();
        Console.Write("Enter Customer Type: ");
        customerTypeEntity.TypeName = Console.ReadLine()!;

        var result = await customerTypeService.CreatCustomerTypeAsync(customerTypeEntity);

        if (result == true)
        {
            Console.WriteLine($"Customer Type {customerTypeEntity.TypeName} was created");
        }
        else
        {
            Console.WriteLine($"Customer Type {customerTypeEntity.TypeName} already exists");
        }

        Console.ReadKey();
    }
}
