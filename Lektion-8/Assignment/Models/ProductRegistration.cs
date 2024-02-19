namespace Assignment.Models;

internal class ProductRegistration
{
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set;} = null!;
    public decimal ProuctPrice { get; set; }
    public string PricingUnit { get; set; } = null!;
    public string ProductCategory{ get; set; } = null!;
}
