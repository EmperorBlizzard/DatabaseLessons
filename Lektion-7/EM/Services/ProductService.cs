using EM.Entites;
using EM.Models;
using EM.Repositories;

namespace EM.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepoitory _categoryRepository;

    public ProductService(ProductRepository productRepository, CategoryRepoitory categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateProductAsync(ProductRegistration form)
    {
        ProductEntity productEntity = form;

        CategoryEntity categoryEntity = await _categoryRepository.GetAsync("SELECT * FROM Categories WHERE CategoryName = @CategoryName", form);
        if (categoryEntity != null)
            productEntity.CategoryId = categoryEntity.Id;

        await _productRepository.CreateAsync("INSERT INTO Products VALUES (@ArticleNumber, @Title, @CategoryId)", productEntity);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var products = await _productRepository.GetAllWithCategoryAsync("SELECT * FROM Products JOIN Categories ON Products.CategoryId = Categories.Id");
        return products;


    }
}
