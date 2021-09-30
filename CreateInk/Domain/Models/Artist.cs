using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Models
{
    public class Artist
    {


        public Guid Id { get; private set; }

        public string UserName { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public virtual ICollection<Art> Arts { get; private set; } = new List<Art>();

        public string Description { get; private set; }

        public Guid RoleId { get; private set; }

        public virtual Role Role { get; private set; }

        public byte [] PasswordHash { get; private set; }

        public byte [] PasswordSalt { get; private set; }

        public static Artist Create(UserDto dto, byte [] passwordHash, byte [] passwordSalt)
        {
            return new Artist()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Description = dto.Description,
                RoleId = dto.Role.Id,
                Arts = null,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

        }

        public UserDto ToDto()
        {
            return new UserDto
            {
                Id = Id,
                Age = Age,
                Arts = Arts?.Select(x => x.ToDto()).ToList(),
                Description = Description,
                FirstName = FirstName,
                LastName = LastName,
                Role = Role.ToDto()
            };
        }

        public void AddArt(Art art)
        {
            Arts.Add(art);
        }

        public UserUpdateDto ToUpdateDto()
        {
            return new UserUpdateDto()
            {
                Id = Id,
                Age = Age,
                Description = Description,
                FirstName = FirstName,
                LastName = LastName,
                RoleId = RoleId
            };
        }

        public void Update(UserUpdateDto dto)
        {
            Id = dto.Id;
            Age = dto.Age;
            Description = dto.Description;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            RoleId = dto.RoleId;
        }
    }
}
