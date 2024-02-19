namespace EM_EntityFramework.Models;

internal class Product
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public string PrimaryCategoryName { get; set; } = null!;
    public string SubCategoryName { get; set; } = null!;
}
