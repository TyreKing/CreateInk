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

        /// <summary>
        /// GetArt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetArt")]
        public IActionResult GetArt(Guid id)
        {
            var result = _artService.GetArt(id);
            return Ok(result);
        }

        /// <summary>
        /// GetArts
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = "GetArts")]
        public IActionResult GetArts()
        {
            var result = _artService.GetArts();
            return Ok(result);

        }
    }
}
