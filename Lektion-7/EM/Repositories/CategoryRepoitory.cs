using EM.Entites;

namespace EM.Repositories;

public class CategoryRepoitory : Repo<CategoryEntity>
{
    public CategoryRepoitory(string databasePath) : base(databasePath)
    {
    }
}
