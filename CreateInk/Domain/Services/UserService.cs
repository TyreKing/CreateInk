using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Helper.AuthenticationHelper;
using CreateInk.Infrastructure.Repositories;
using CreateInk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepo;
        private CreateInkContext _context;

        

        public UserService(CreateInkContext context)
        {
            _userRepo = new UserRepository(context);
            _context = context;
          
        }

        public UserDto Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Artists.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user.ToDto();
        }



        public UserDto GetArtist(Guid id)
        {
            try
            {
                var artist = _userRepo.GetById(id);
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
            var artists = _userRepo.GetArtists().ToList();
            return artists.Select(x => x.ToDto());
        }

        public Guid CreateArtist(UserDto artistDto)
        {
            if (string.IsNullOrWhiteSpace(artistDto.Password))
            {
                throw new AuthenticationException("Password required");
            }

            if(_userRepo.GetArtists().Any(x => x.UserName == artistDto.UserName))
            {
                throw new AuthenticationException($"Username \"{artistDto.UserName}\" is already taken");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(artistDto.Password, out passwordHash, out passwordSalt);

            var artist = Artist.Create(artistDto, passwordHash, passwordSalt);
            _context.Artists.Add(artist); 
            _context.SaveChanges();
            return artist.Id;
        }

        public void DeleteArtist(Guid artistId)
        {
            try
            {
                var artist = _userRepo.GetById(artistId);
                if (artist == null)
                {
                    throw new KeyNotFoundException("Artist Does Not Exist.");
                }

                _context.Remove(artist);
                _context.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            } 
        }

        public Guid AddArt(ArtDto artDto)
        {
            var artist = _userRepo.GetById(artDto.ArtistId);
            if (null == artist.Id)
            {
                throw new KeyNotFoundException("Artist Not Exist");
            }
            var art = Art.Create(artDto);
            _context.Arts.Add(art);
            //_Context.SaveChanges();
            artist.AddArt(art);
            _context.SaveChanges();
            return artist.Id;
        }

        public Guid UpdateArtist(Guid id, JsonPatchDocument<UserUpdateDto> patch)
        {
            var artist = _userRepo.GetById(id);
            if (null == artist.Id)
            {
                throw new KeyNotFoundException("Artist Not Exist");
            }
            var artistUpdate= artist.ToUpdateDto();
            patch.ApplyTo(artistUpdate);
            artist.Update(artistUpdate);
            _context.Artists.Update(artist);
            return artist.Id;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

    }
}
