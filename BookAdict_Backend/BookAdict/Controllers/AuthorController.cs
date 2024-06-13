using AutoMapper;
using BookAdict.Interfaces;
using BookAddict.Application.DTOS.AuthorDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookAddict.Application.Queries.AuthorQueries;
using BookAddict.Application.Commands.AuthorCommands;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAuthors()
        {
            var query = new GetAllAuthorsRequest();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("GetAuthor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var query = new GetAuthorByIdRequest(id);
            var result = await _mediator.Send(query);
            return result.Message != string.Empty ?  NotFound(result.Message) : Ok(result);
        }
        [HttpGet("SearchAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchAuthors([FromQuery] string searchText)
        {

            var query = new SearchAuthorsRequest(searchText);
            var result = await _mediator.Send(query);
            return result.Count() > 0 ? Ok(result) : NotFound(new { message = "no author found"});
        }
        [HttpPost("AddAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAuthor([FromForm] AuthorInDto authorInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = new AddAuthorRequest(authorInDto);
            await _mediator.Send(command);
            return Ok("Author Added Succefully");
        }
        [HttpPut("UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAuthor([FromForm] AuthorInDto authorInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(new UpdateAuthorRequest(authorInDto));
            return Ok("Author Updated Successfully");
        }
        [HttpDelete("DeleteAuthor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var command = new DeleteAuthorRequest(id);
            var result = await _mediator.Send(command);
            return result ? Ok(new {message = "Deleted Successfully Ok"}) : BadRequest(new { message = "Something went wrong" });
        }
    }
}
