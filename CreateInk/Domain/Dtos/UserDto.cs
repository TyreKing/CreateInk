using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Domain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public List<ArtDto> Arts { get; set; } = new List<ArtDto>();

        public string Description { get; set; }

        public RoleDto Role { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
