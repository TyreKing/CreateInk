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

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public virtual ICollection<Art> Arts { get; private set; } = new List<Art>();

        public string Description { get; private set; }

        public Guid RoleId { get; private set; }

        public virtual Role Role { get; private set; }

        public static Artist Create(UserDto dto)
        {
            return new Artist()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Description = dto.Description,
                RoleId = dto.Role.Id,
                Arts = null
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

        //public static Artist Update(UserDto dto)
        //{
        //   // var Artist = new Artist();
        //   //var artist =  AutoMapper.Mapper.Map<UserDto, Artist>(dto, Artist);
        //   // dbContext.Save();
        //}
    }
}
