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

        /// <summary>
        /// Get Artist by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Artist GetById(Guid id)
        {
            var artist = _context.Artists
                .Include(x => x.Role).ThenInclude(x => x.Permissions)
                .Include(x => x.Arts)
                .SingleOrDefault(x => x.Id == id);
            return artist;
        }


        /// <summary>
        /// Get all artists
        /// </summary>
        /// <returns></returns>
        public IQueryable<Artist> GetArtists()
        {
            return _context.Artists
                .Include(x => x.Role).ThenInclude(x => x.Permissions)
                .Include(x => x.Arts)
                .Where(x => x.RoleId == RolesEnum.Attribute[(int)AccessRoles.Artist]);
        }

        
        
    }
}
