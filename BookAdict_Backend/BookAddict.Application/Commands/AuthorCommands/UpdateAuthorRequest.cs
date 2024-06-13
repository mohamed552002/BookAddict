using BookAddict.Application.DTOS.AuthorDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Commands.AuthorCommands
{
    public class UpdateAuthorRequest : IRequest
    {
        public AuthorInDto AuthorDto { get;}

        public UpdateAuthorRequest(AuthorInDto authorDto)
        {
            AuthorDto = authorDto;
        }
    }
}
