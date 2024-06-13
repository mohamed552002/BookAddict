using BookAddict.Application.DTOS.AuthorDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Commands.AuthorCommands
{
    public class AddAuthorRequest : IRequest
    {
        public AuthorInDto AuthorInDto { get; }

        public AddAuthorRequest(AuthorInDto authorInDto)
        {
            AuthorInDto = authorInDto;
        }
    }
}
