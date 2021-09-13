using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Domain.Enum
{
    public enum AccessRoles
    {
        Artist = 1,
        Admin = 2,
    }


    public class RolesEnum
    {
        public static Dictionary<int, Guid> Attribute = new Dictionary<int, Guid>()
        {
            {(int)AccessRoles.Artist, Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6")},
            {(int)AccessRoles.Admin, Guid.Parse("795DF5BE-7260-4857-AEF0-2C2288D026B0")},    
        };
    }
}
