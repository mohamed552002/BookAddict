using AutoMapper;
using BookAdict.Commands;
using BookAdict.Interfaces;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using MediatR;

namespace BookAdict.Handlers.BookHandler
{
    public class DeleteBookHandler : IRequestHandler<DeleteBooksRequest, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public DeleteBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }

        public async Task<Book> Handle(DeleteBooksRequest request, CancellationToken cancellationToken)
        {
            var Deletedbook = await _unitOfWork.Books.DeleteBookAsync(request.Id);
            if (Deletedbook != null)
            {
                _imageServices.DeleteImage(Deletedbook.ImageUrl);
                _unitOfWork.ActionOnComplete();
            }
            return Deletedbook;
        }
    }
}
