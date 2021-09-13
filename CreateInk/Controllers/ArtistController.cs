using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {

        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistServices _artistServices;


        public ArtistController(ILogger<ArtistController> logger, IArtistServices ArtistService)
        {
            _logger = logger;
            _artistServices = ArtistService;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromBody] Guid id)
        {
            var result = _artistServices.GetArtist(id);
            return Ok();
        }
    }
}
