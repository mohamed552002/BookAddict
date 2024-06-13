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
    public class GetAllAuthorHandler : IRequestHandler<GetAllAuthorsRequest, IEnumerable<AuthorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllAuthorHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<AuthorDto>>(await _unitOfWork.Author.GetAuthorsAsync());
        }
    }
}
