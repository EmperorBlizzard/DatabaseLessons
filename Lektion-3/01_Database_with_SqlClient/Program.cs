using _01_Database_with_SqlClient.Models;
using _01_Database_with_SqlClient.Services;


var product = new Product()
{
    Name = "Logitech G535 LIGHTSPEED Wireless Gaming Headset - BLACK",
    Description = "Bekväm gamingheadset med hög prestanda",
    Price = 890
};

var productSevice = new ProductService();
var productId = productSevice.Create(product);


foreach (var item in productSevice.GetALL())
{
    Console.WriteLine($"{item.Name} {item.Price} kr");
}

Console.WriteLine();

product.Id = (int)productId!;
product.Description = "New Description";
product.Price = 1119;
productSevice.Update(product);

foreach (var item in productSevice.GetALL())
{
    Console.WriteLine($"{item.Name} {item.Price} kr");
}
//Decimal.Truncate(item.Price)
//Console.WriteLine(productId);
Console.ReadKey();
