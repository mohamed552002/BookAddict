using BookAddict.Application.DTOS.AuthorDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Queries.AuthorQueries
{
    public class GetAllAuthorsRequest : IRequest<IEnumerable<AuthorDto>>
    {}
}
