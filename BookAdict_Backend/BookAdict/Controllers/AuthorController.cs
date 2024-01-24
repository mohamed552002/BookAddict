using AutoMapper;
using BookAdict.Interfaces;
using DataRepository.Core.DTOS.AuthorDtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {

        public AuthorController(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices):base(unitOfWork,mapper,imageServices)
        {

        }

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(_mapper.Map<List<AuthorDto>>(await _unitOfWork.Author.GetAuthorsAsync()));
        }
        [HttpGet("GetAuthor/{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _unitOfWork.Author.GetAuthorAsync(id);
            author.ImageUrl = _imageServices.HandleGetImgUrl(author.ImageUrl);
            if (author == null)
                return NotFound("No Author with this id found");
            return Ok(_mapper.Map<AuthorDto>(author));
        }
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromForm] AuthorInDto authorInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var author = _mapper.Map<Author>(authorInDto);
            author.ImageUrl = _imageServices.SetImage(authorInDto.ImageFile);
            await _unitOfWork.Author.AddAuthorAsync(author);
            return Ok(author);
        }
        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromForm] AuthorInDto authorInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var author = _mapper.Map<Author>(authorInDto);
            author.ImageUrl = _imageServices.EditImage(authorInDto.ImageFile, authorInDto.ImageUrl);
            await _unitOfWork.Author.UpdateAuthorAsync(author);
            return Ok(author);
        }
        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _unitOfWork.Author.GetAuthorAsync(id);
            if (author == null)
                return BadRequest("No author with this id found");
            _imageServices.DeleteImage(author.ImageUrl);
            await _unitOfWork.Author.DeleteAuthorAsync(author);
            return Ok(new {message = "Ok"});
        }
    }
}
