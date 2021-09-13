using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Domain.Dtos
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<PermissionDto> Permissions { get; set; }
    }
}
