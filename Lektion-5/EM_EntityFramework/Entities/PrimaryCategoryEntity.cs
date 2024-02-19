namespace EM_EntityFramework.Entities;

internal class PrimaryCategoryEntity
{
    public int Id { set; get; }
    public string CategoryName { get; set; } = null!;
    public ICollection<SubCategoryEntity> SubCategories { get; set; } = new HashSet<SubCategoryEntity>();
}