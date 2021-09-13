using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Services
{
    public class ArtistServices : IArtistServices
    {
        private ArtistRepository _ArtistRepo;

        public ArtistServices(CreateInkContext context)
        {
            _ArtistRepo = new ArtistRepository(context);
        }

        public ArtistDto GetArtist(Guid id)
        {
            try
            {
                var artist = _ArtistRepo.GetById(id);
                if (null == artist)
                {
                    throw new Exception("Artist Not Found");
                }
                return artist.ToDto();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
