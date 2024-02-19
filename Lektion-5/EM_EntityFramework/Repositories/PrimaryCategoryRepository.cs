using EM_EntityFramework.Contexts;
using EM_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_EntityFramework.Repositories
{
    internal class PrimaryCategoryRepository : Repo<PrimaryCategoryEntity>
    {
        private readonly DataContext _context;
        public PrimaryCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<PrimaryCategoryEntity>> ReadAsync()
        {
            var result = await _context.PrimaryCategories.Include(x => x.SubCategories).ToListAsync();
            return result;
        }
    }
}
