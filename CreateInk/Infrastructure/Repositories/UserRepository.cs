using CreateInk.Context;
using CreateInk.Domain.Enum;
using CreateInk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Infrastructure.Repositories
{
    public class UserRepository
    {
        private CreateInkContext _context;
        public UserRepository(CreateInkContext context) 
        {
            _context = context;
        }

        public Artist GetById(Guid id)
        {
            var artist = _context.Artists.FirstOrDefault(x => x.Id == id);
            return artist;
        }

        public IQueryable<Artist> GetArtists()
        {
            return _context.Artists.Include(x => x.Role).ThenInclude(x => x.Permissions).Where(x => x.RoleId == RolesEnum.Attribute[(int)AccessRoles.Artist]);
             //_context.Artists.Where(x => x.RoleId == RolesEnum.Attribute[(int)AccessRoles.Artist]);
        }

        
        
    }
}
