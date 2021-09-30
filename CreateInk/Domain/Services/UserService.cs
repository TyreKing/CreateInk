using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Infrastructure.Repositories;
using CreateInk.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Services
{
    public class UserService : IUserService
    {
        private UserRepository _UserRepo;
        private ArtRepository _artRepo;
        private CreateInkContext _Context; 

        public UserService(CreateInkContext context)
        {
            _UserRepo = new UserRepository(context);
            _artRepo = new ArtRepository(context);
            _Context = context;
        }

        public UserDto GetArtist(Guid id)
        {
            try
            {
                var artist = _UserRepo.GetById(id);
                if (null == artist)
                {
                    throw new KeyNotFoundException("Artist Not Found");
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
            var artist = Artist.Create(artistDto);
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
                    throw new KeyNotFoundException("Artist Does Not Exist.");
                }

                _Context.Remove(artist);
                _Context.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            } 
        }

        public Guid AddArt(ArtDto artDto)
        {
            var artist = _UserRepo.GetById(artDto.ArtistId);
            if (null == artist.Id)
            {
                throw new KeyNotFoundException("Artist Not Exist");
            }
            var art = Art.Create(artDto);
            _Context.Arts.Add(art);
            //_Context.SaveChanges();
            artist.AddArt(art);
            _Context.SaveChanges();
            return artist.Id;
        }

        public Guid UpdateArtist(Guid id, JsonPatchDocument<UserUpdateDto> patch)
        {
            var artist = _UserRepo.GetById(id);
            if (null == artist.Id)
            {
                throw new KeyNotFoundException("Artist Not Exist");
            }
            var artistUpdate= artist.ToUpdateDto();
            patch.ApplyTo(artistUpdate);
            artist.Update(artistUpdate);
            _Context.Artists.Update(artist);
            return artist.Id;
        }
    }
}
