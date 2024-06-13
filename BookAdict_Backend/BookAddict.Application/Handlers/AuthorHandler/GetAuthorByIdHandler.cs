using AutoMapper;
using BookAddict.Application.DTOS.AuthorDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Application.Queries.AuthorQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Handlers.AuthorHandler
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdRequest, AuthorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAuthorByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AuthorDto> Handle(GetAuthorByIdRequest request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Author.GetAuthorAsync(request.Id);
            if (author == null)
                return new AuthorDto() { Message = "No Author found with this id"};
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
