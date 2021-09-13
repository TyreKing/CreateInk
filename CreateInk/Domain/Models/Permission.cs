using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Models
{
    public class Permission
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public PermissionDto ToDto()
        {
            return new PermissionDto
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
