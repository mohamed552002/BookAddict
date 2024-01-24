using AutoMapper;
using BookAdict.Interfaces;
using BookAdict.Queries.BookQueries;
using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.Interfaces;
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
            return  _mapper.Map<List<BookDto>>(await _unitOfWork.Books.GetAllBooksAsync());
        }
    }
}
