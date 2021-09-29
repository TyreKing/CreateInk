using CreateInk.Context;
using CreateInk.Controllers.ViewModels;
using CreateInk.Services;
using Microsoft.AspNetCore.JsonPatch;
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


        [HttpPost("")]
        public IActionResult CreateArtist([FromBody] ArtistVm artistVm)
        {
            var artistId = _userService.CreateArtist(artistVm.ToDto());
            return CreatedAtAction("GetArtist", artistId);
        }

        [HttpDelete("id")]
        public IActionResult DeleteArtist([FromQuery] Guid id)
        {
            _userService.DeleteArtist(id);
            return Ok();
        }

       [HttpPost("art")]
       public IActionResult AddArt([FromBody] ArtVm artVm)
        {
            var artistId = _userService.AddArt(artVm.ToDto());
            return Ok(artistId);
        }

        [HttpPatch("{Id}")]
        public IActionResult UpdateArtist([FromQuery]Guid id, [FromBody] JsonPatchDocument<ArtistVm> patch)
        {
           // var artist = _userService.UpdateArtist(id, patch);
            
            return Ok();
        }
    }
}
