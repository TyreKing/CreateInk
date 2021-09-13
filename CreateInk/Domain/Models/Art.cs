using CreateInk.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Models
{
    public class Art
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Date { get; private set; }

        public Guid ArtistId { get; private set; }

        public virtual Artist Artist { get; private set; }

        public ArtDto ToDto()
        {
            return new ArtDto
            {
                Description = Description,
                Artist = Artist.ToDto(),
                Date = Date,
                Id = Id,
                Name = Name
            };
        }
        
    }
}
