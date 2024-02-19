using Assignment.Contexts;
using Assignment.Entites;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repostitories
{
    internal class CustomserRepository : Repo<CustomerEntity>
    {
        private readonly DataContext _context;
        public CustomserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.Include(x => x.Address).ToListAsync();
        }
    }
}
