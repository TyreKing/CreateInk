using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Controllers.ViewModels
{
    public class ArtistVm
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

    }
}
