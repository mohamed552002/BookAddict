using AutoMapper;
using BookAdict.Commands;
using BookAdict.Interfaces;
using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Handlers.BookHandler
{
    public class AddBookHandler : IRequestHandler<AddBookRequest, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public AddBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }
        public async Task<Book> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {
                var book = _mapper.Map<Book>(request.BookDto);
                book.ImageUrl = _imageServices.SetImage(request.BookDto.ImgFile);
                await _unitOfWork.Books.AddBookAsync(book, request.BookDto.AuthorsIds);
                _unitOfWork.ActionOnComplete();
                return book;
        }
    }
}
