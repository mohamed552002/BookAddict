using AutoMapper;
using BookAdict.DTOS;
using BookAdict.Interfaces;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase

    {
        //private readonly IBaseRepository<Book> _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public BookController(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookDtos = _mapper.Map<List<BookDto>>(await _unitOfWork.Books.GetAllBooksAsync());
            return Ok(bookDtos);
        }
        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var bookDto = _mapper.Map<BookDto>(await _unitOfWork.Books.GetBookAsync(id));
            return Ok(bookDto);
        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromForm] BookInsertDto bookInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var book = _mapper.Map<Book>(bookInDto);
            book.ImageUrl = _imageServices.SetImage(bookInDto.ImgFile);
            _unitOfWork.Books.AddBookAsync(book,bookInDto.AuthorsIds);
            _unitOfWork.ActionOnComplete();
                return Ok(book);
            
        }
    }
}
