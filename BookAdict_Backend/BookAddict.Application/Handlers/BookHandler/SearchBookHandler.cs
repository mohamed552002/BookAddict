using AutoMapper;
using BookAdict.Interfaces;
using BookAdict.Queries.BookQueries;
using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Application.Interfaces;
using MediatR;

namespace BookAdict.Handlers.BookHandler
{
    public class SearchBookHandler : IRequestHandler<SearchBookQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BookDto>> Handle(SearchBookQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<BookDto>>(await _unitOfWork.Books.SearchBookByName(request.SearchText));

    }
}
