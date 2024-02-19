using Microsoft.EntityFrameworkCore;

namespace FM_EntityFrameworkCore.Entities;

[Index(nameof(TypeName), IsUnique = true)]
internal class CustomerTypeEntity
{
    public int Id { set; get; }
    public string TypeName { get; set; } = null!;

    public ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
}