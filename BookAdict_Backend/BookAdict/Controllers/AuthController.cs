using BookAdict.Commands;
using BookAdict.Commands.AuthCommands;
using BookAdict.Queries.AuthQueries;
using DataRepository.Core.Dtos;
using DataRepository.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterRequestDto registerModel)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var registerCommand = new RegisterUserRequest(registerModel);
            var result = await _mediator.Send(registerCommand);
            return result.IsAuthenticated ? Ok(result)  : BadRequest(result);
        }
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestDto tokenModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tokenCommand = new GetTokenRequest(tokenModel);
            var result = await _mediator.Send(tokenCommand);
            return result.IsAuthenticated ? Ok(result) : BadRequest(result);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleDto roleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var roleCommand = new AddRoleRequest(roleModel);
            var result = await _mediator.Send(roleCommand);
            return result.IsNullOrEmpty() ? Ok(result): BadRequest(result);
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userQuery = new GetAllUsersRequest();
            var result = await _mediator.Send(userQuery);
            return Ok(result);
        }
    }
}
