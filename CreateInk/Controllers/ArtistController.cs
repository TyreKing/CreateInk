using CreateInk.Context;
using CreateInk.Services;
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
        private readonly IUserService _userService;


        public ArtistController(ILogger<ArtistController> logger, IUserService artistServices)
        {
            _logger = logger;
            _userService = artistServices;
        }

        
        [HttpGet("")] //https://localhost:44369/artist
        public IActionResult GetArtists()
        {
            var result = _userService.GetArtists();
            return Ok(result);
        }

        [HttpGet("{id}")] //https://localhost:44369/artist/id?id=...
        public IActionResult GetArtist([FromQuery] Guid id)
        {
            var result = _userService.GetArtist(id);
            return Ok(result);
        }


        //[HttpPost("")]
        //public IActionResult CreateArtist()

       
    }
}
