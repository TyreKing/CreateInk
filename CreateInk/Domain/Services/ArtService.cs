using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Domain.Interfaces;
using CreateInk.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Domain.Services
{
    public class ArtService : IArtService
    {
        private ArtRepository _artRepo;
        public ArtService(CreateInkContext context)
        {
            _artRepo = new ArtRepository(context);
        }

       

        public ArtDto GetArt(Guid id)
        {
            var art = _artRepo.GetById(id);

            return art.ToDto();
        }

        public IEnumerable<ArtDto> GetArts()
        {
            var arts = _artRepo.GetArts();
            return arts.Select(x => x.ToDto()).ToList();
        }
    }
}
