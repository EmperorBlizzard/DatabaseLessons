using FM.Entites;

namespace FM.Models;

internal class ProductRegistartion
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public int CategoryName { get; set; }
    public CategoryEntity Category { get; set; } = new CategoryEntity();
}
