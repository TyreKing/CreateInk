using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Services
{
    public class UserService : IUserService
    {
        private UserRepository _UserRepo;

        public UserService(CreateInkContext context)
        {
            _UserRepo = new UserRepository(context);
        }

        public UserDto GetArtist(Guid id)
        {
            try
            {
                var artist = _UserRepo.GetById(id);
                if (null == artist)
                {
                    throw new Exception("Artist Not Found");
                }
                return artist.ToDto();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<UserDto> GetArtists()
        {
            var artists = _UserRepo.GetArtists().ToList();
            return artists.Select(x => x.ToDto());
        }
    }
}
