using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk
{
    public interface IUserService
    {
        public UserDto GetArtist(Guid id);

        public IEnumerable<UserDto> GetArtists();

        public Guid CreateArtist(UserDto artistDto);

    }
}
