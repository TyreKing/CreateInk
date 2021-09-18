using CreateInk.Context;
using CreateInk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Infrastructure.Repositories
{
    public class ArtRepository
    {
        private CreateInkContext _context;

        public ArtRepository(CreateInkContext context)
        {
            _context = context;
        }

        public Art GetById(Guid Id)
        {
            var art = _context.Arts.FirstOrDefault(x => x.Id == Id);
            return art;
        }

        public IQueryable<Art> GetArts()
        {
            var arts = _context.Arts.Select(x => x);
            return arts;
        }
    }
}
