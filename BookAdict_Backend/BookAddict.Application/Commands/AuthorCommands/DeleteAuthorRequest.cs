using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Commands.AuthorCommands
{
    public class DeleteAuthorRequest : IRequest<bool>
    {
        public int Id { get; }

        public DeleteAuthorRequest(int id)
        {
            Id = id;
        }
    }
}
