using FM.Entites;
using FM.Models;

namespace FM.Services;

internal class ProductService
{
    //public async Task CreateAsync(ProductRegistartion productRegistion)
    //{
    //    ProductEntity productEntity = productRegistion;
    //    var categoryEntity = await _categoryRepository.GetAsync(x => x.CategoryName == productEntity.Category.CategoryName);

    //    if (categoryEntity != null)
    //    {
    //        productEntity.Category = categoryEntity;
    //    }
    //    await _productRepository.CreateAsync(productEntity);
    //}





    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        List<Product> products = new List<Product>
        {
            new Product{ ArticleNumber = "1", Title = "Product 1" },
            new Product{ ArticleNumber = "2", Title = "Product 2" },
            new Product{ ArticleNumber = "3", Title = "Product 3" }
        };

        return products;
    }
}
