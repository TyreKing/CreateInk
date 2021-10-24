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
using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.Filters;
using CreateInk.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CreateInk.Helpers.AuthenticationHelper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CreateInk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {

        private readonly ILogger<ArtistController> _logger;
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public ArtistController(ILogger<ArtistController> logger, IUserService artistServices, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _userService = artistServices;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateVm model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
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
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("create", Name = "CreateArtist")]
        public IActionResult CreateArtist([FromBody] ArtistVm artistVm)
        {       
            // create user
            var userId = _userService.CreateArtist(artistVm.ToDto());
            return Ok(userId);                     
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
        [SwaggerRequestExample(typeof(Helper.Operation), typeof(JsonPatchUserRequestExample))]
        [HttpPatch("{Id}", Name = "UpdateArtist")]
        public IActionResult UpdateArtist(Guid id, [FromBody] JsonPatchDocument<UserUpdateDto> patch)
        {
            _userService.UpdateArtist(id, patch);
            return Ok();
        }
    }
}
