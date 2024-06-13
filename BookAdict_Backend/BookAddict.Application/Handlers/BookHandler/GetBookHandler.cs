using AutoMapper;
using BookAdict.Interfaces;
using BookAdict.Queries.BookQueries;
using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Application.Interfaces;
using MediatR;

namespace BookAdict.Handlers.BookHandler
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public GetBookHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }
        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var bookDto = _mapper.Map<BookDto>(await _unitOfWork.Books.GetBookAsync(request.BookId));
            if (bookDto == null)
                return null;
            return bookDto;
        }
    }
}
