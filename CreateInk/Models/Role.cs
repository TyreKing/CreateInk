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
    }
}
