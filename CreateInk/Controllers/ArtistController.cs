using CreateInk.Context;
using CreateInk.Controllers.ViewModels;
using CreateInk.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreateInk.Domain.Dtos;
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

        /// <summary>
        /// GetArtists
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = "GetArtists")] //https://localhost:44369/artist
        public IActionResult GetArtists()
        {
            var result = _userService.GetArtists();
            return Ok(result);
        }

        /// <summary>
        /// GetArtist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetArtist")] //https://localhost:44369/artist/id?id=...
        public IActionResult GetArtist(Guid id)
        {
            var result = _userService.GetArtist(id);
            return Ok(result);
        }

        /// <summary>
        /// CreateArtist
        /// </summary>
        /// <param name="artistVm"></param>
        /// <returns></returns>
        [HttpPost("", Name = "CreateArtist")]
        public IActionResult CreateArtist([FromBody] ArtistVm artistVm)
        {
            var artistId = _userService.CreateArtist(artistVm.ToDto());
            return CreatedAtAction("GetArtist", artistId);
        }

        /// <summary>
        /// DeleteArtist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteArtist")]
        public IActionResult DeleteArtist(Guid id)
        {
            _userService.DeleteArtist(id);
            return Ok();
        }

        /// <summary>
        /// AddArt
        /// </summary>
        /// <param name="artVm"></param>
        /// <returns></returns>
        [HttpPost("art", Name = "AddArt")]
       public IActionResult AddArt([FromBody] ArtVm artVm)
        {
            var artistId = _userService.AddArt(artVm.ToDto());
            return Ok(artistId);
        }
        /// <summary>
        /// UpdateArtist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patch"></param>
        /// <returns></returns>
        [HttpPatch("{Id}", Name = "UpdateArtist")]
        public IActionResult UpdateArtist(Guid id, [FromBody] JsonPatchDocument<UserUpdateDto> patch)
        {
            _userService.UpdateArtist(id, patch);
            return Ok();
        }
    }
}
