using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk
{
    public interface IArtistServices 
    {
       public ArtistDto GetArtist(Guid id);
    }
}
