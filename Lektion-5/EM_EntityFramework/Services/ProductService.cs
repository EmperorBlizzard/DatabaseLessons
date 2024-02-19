using EM_EntityFramework.Entities;
using EM_EntityFramework.Models;
using EM_EntityFramework.Repositories;

namespace EM_EntityFramework.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly SubCategoryRepository _subCategoryRepo;

    public ProductService(ProductRepository productRepo, SubCategoryRepository subCategoryRepo)
    {
        _productRepo = productRepo;
        _subCategoryRepo = subCategoryRepo;
    }

    public async Task<ProductEntity> CreateProductAsync(ProductRegistration registration)
    {
        var item = await _productRepo.ReadAsync(x => x.Articlenumber == registration.ArticleNumber);
        if (item == null)
        {
            var entity = new ProductEntity
            {
                Articlenumber = registration.ArticleNumber,
                Name = registration.Name,
                Description = registration.Description,
                Price = registration.Price,
                SubCategoryId = (await _subCategoryRepo.ReadAsync(x => x.SubCategoryName == registration.SubCategoryName)).Id,
            };
            entity = await _productRepo.CreateAsync(entity);

            var product = new Product
            {
                ArticleNumber = entity.Articlenumber,
                Name = registration.Name,
                Description = registration.Description,
                Price = registration.Price,
                SubCategoryName = entity.SubCategory.SubCategoryName,
                PrimaryCategoryName = entity.SubCategory.PrimaryCategory.CategoryName
            };
            return entity;
        }

        return null!;
    }
}
