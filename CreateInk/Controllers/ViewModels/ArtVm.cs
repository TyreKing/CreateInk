using CreateInk.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Controllers.ViewModels
{
    public class ArtVm
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("artistId")]
        public  Guid ArtistId { get; set; }

        public ArtDto ToDto()
        {
            return new ArtDto
            {
                ArtistId = ArtistId,
                Date = Date,
                Description = Description,
                Name = Name
            };
        }
    }
}
