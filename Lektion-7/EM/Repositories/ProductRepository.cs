using Dapper;
using EM.Entites;
using EM.Models;

namespace EM.Repositories;

public class ProductRepository : Repo<ProductEntity>
{
    public ProductRepository(string databasePath) : base(databasePath)
    {
    }

    public virtual async Task<IEnumerable<Product>> GetAllWithCategoryAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            return await connection.QueryAsync<Product>(query, param);
        }
        catch (Exception ex) { }
        return null;
    }
}
