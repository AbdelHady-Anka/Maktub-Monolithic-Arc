using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Maktoob.Application;
using Maktoob.Application.Users;
using Maktoob.CrossCuttingConcerns.Result;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Maktoob.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public UsersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await _dispatcher.DispatchAsync(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInUserCommand command)
        {
            var result = await _dispatcher.DispatchAsync(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var result = await _dispatcher.DispatchAsync(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("signOut")]
        [Authorize]
        public async Task<IActionResult> SignOut([FromBody] SignOutUserCommand command)
        {
            command.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            command.JwtId = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            var result = await _dispatcher.DispatchAsync(command);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }   

        // GET: api/User
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/User
        
        // PUT: api/User/5
        [HttpPatch("{id}")]
        public void Put(int id, [FromBody] JsonPatchDocument value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
