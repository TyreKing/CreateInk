using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public RoleDto ToDto()
        {
            return new RoleDto
            {
                Name = Name,
                Id = Id,
                Permissions = Permissions.Select(x => x.ToDto()).ToList()
            };
        }

        public static Role Create(RoleDto dto)
        {
            return new Role()
            {
                Id = dto.Id,
                Name = dto.Name,
                Permissions = null
            };
        }
    }
}
