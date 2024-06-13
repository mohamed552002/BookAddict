using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Domain.Models;
using MediatR;

namespace BookAdict.Commands
{
    public class AddBookRequest:IRequest<Book>
    {
        public BookInsertDto BookDto { get; }

        public AddBookRequest(BookInsertDto bookDto)
        {
            BookDto = bookDto;
        }
    }
}
