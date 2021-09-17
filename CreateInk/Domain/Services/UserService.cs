using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Infrastructure.Repositories;
using CreateInk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Services
{
    public class UserService : IUserService
    {
        private UserRepository _UserRepo;
        private CreateInkContext _Context; 

        public UserService(CreateInkContext context)
        {
            _UserRepo = new UserRepository(context);
            _Context = context;
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

        public Guid CreateArtist(UserDto artistDto)
        {
            var artist = new Artist().Create(artistDto);
            _Context.Artists.Add(artist); 
            _Context.SaveChanges();
            return artist.Id;
        }

        public void DeleteArtist(Guid artistId)
        {
            try
            {
                var artist = _UserRepo.GetById(artistId);
                if (artist == null)
                {
                    throw new Exception("Artist does not exist.");
                }

                _Context.Remove(artist);
                _Context.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            } 
        }
    }
}
