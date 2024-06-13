using AutoMapper;
using BookAdict.Interfaces;
using BookAdict.Queries.BookQueries;
using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Application.Interfaces;
using MediatR;

namespace BookAdict.Handlers.BookHandler
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public GetAllBooksHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.Books.GetAllBooksAsync(request.SortBy, request.CategoryName);
            return  _mapper.Map<List<BookDto>>(books);
        }
    }
}
