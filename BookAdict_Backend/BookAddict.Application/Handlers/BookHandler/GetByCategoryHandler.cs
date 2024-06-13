using AutoMapper;
using BookAdict.Interfaces;
using BookAdict.Queries.BookQueries;
using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Application.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace BookAdict.Handlers.BookHandler
{
    public class GetByCategoryHandler : IRequestHandler<GetByCategoryQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageServices _imageServices;

        public GetByCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageServices = imageServices;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetByCategoryQuery request, CancellationToken cancellationToken)
        {
            var BooksDto = _mapper.Map<IEnumerable<BookDto>>(await _unitOfWork.Books.GetBooksByCategoryIdAsync(request.CategoryId));
            return BooksDto;
        }
    }
}
