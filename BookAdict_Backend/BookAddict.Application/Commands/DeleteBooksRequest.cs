using BookAddict.Domain.Models;
using MediatR;

namespace BookAdict.Commands
{
    public class DeleteBooksRequest:IRequest<Book>
    {
        public int Id { get; }

        public DeleteBooksRequest(int id)
        {
            Id = id;
        }
    }
}
