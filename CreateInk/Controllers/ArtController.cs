using CreateInk.Domain.Interfaces;
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
    public class ArtController : ControllerBase
    {
        private ILogger<ArtController> _logger;
        private readonly IArtService _artService;

        public ArtController(ILogger<ArtController> logger, IArtService artService)
        {
            _artService = artService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetArt([FromQuery]Guid id)
        {
            var result = _artService.GetArt(id);
            return Ok(result);
        }

        [HttpGet("")]
        public IActionResult GetArts()
        {
            var result = _artService.GetArts();
            return Ok(result);

        }
    }
}
