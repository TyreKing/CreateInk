using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Domain.Interfaces
{
    public interface IArtService
    {
        public ArtDto GetArt(Guid id);

        public IEnumerable<ArtDto>GetArts();
        
        
    }
}
