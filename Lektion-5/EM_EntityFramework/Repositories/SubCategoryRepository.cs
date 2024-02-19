using EM_EntityFramework.Contexts;
using EM_EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_EntityFramework.Repositories
{
    internal class SubCategoryRepository : Repo<SubCategoryEntity>
    {
        private readonly DataContext _context;
        public SubCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
