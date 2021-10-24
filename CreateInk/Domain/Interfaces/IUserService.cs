using CreateInk.Domain.Dtos;
using Microsoft.AspNetCore.JsonPatch;
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

        public void DeleteArtist(Guid artistId);

        public Guid AddArt(ArtDto artDto);

        Guid UpdateArtist(Guid id, JsonPatchDocument<UserUpdateDto> patch);

        UserDto Authenticate(string username, string password);


    }
}
