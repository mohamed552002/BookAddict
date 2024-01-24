using AutoMapper;
using BookAdict.Commands;
using BookAdict.Interfaces;
using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Handlers.BookHandler
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public UpdateBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }
        public async Task<Book> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {

            if (!_unitOfWork.Books.IsBookExist(request.BookDto.Id))
                return null;
            var book = _mapper.Map<Book>(request.BookDto);
            book.ImageUrl = _imageServices.EditImage(request.BookDto.ImgFile, request.BookDto.ImgUrl);
            await _unitOfWork.Books.UpdateBookAsync(book, request.BookDto.AuthorsIds);
            _unitOfWork.ActionOnComplete();
            return book;
        }
    }
}
