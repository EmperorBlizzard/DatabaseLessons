using FM_EntityFramework.Contexts;
using FM_EntityFramework.Models;
using FM_EntityFramework.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FM_EntityFramework.Services;

internal class ProductService
{
    private readonly DataContext _context;
    private readonly CategoryService _categoryService;

    public ProductService(DataContext context, CategoryService categoryService)
    {
        _context = context;
        _categoryService = categoryService;
    }

    public async Task CreateProductAsync (ProductRegistration product)
    {
        var categoryEntity = await _categoryService.GetCategoryAsync(x => x.CategoryName == product.CategoryName);

        if (categoryEntity == null)
        {
            await _categoryService.CreateCategoryAsync(product.CategoryName);
            categoryEntity = await _categoryService.GetCategoryAsync(x => x.CategoryName == product.CategoryName);
        }

        var productEntity = new ProductEntity
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = categoryEntity.Id
        };

        _context.Products.Add(productEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        var products = await _context.Products.Include(x => x.Category).ToListAsync();
        return products;
    }



    //public async Task<ProductEntity> GetProductAsync(Expression<Func<ProductEntity, bool>> predicate)
    //{
    //    var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(predicate);
    //    return productEntity ?? null!;
    //}
}
