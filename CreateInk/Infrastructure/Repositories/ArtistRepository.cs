using CreateInk.Context;
using CreateInk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Infrastructure.Repositories
{
    public class ArtistRepository
    {
        private CreateInkContext _context;
        public ArtistRepository(CreateInkContext context) 
        {
            _context = context;
        }

        public Artist GetById(Guid id)
        {
            var artist = _context.Artists.FirstOrDefault(x => x.Id == id);
            return artist;
        }
    }
}
