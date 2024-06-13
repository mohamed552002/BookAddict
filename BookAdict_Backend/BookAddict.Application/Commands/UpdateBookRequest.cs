using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Domain.Models;
using MediatR;

namespace BookAdict.Commands
{
    public class UpdateBookRequest:IRequest<Book>
    {
        public BookInsertDto BookDto { get; }

        public UpdateBookRequest(BookInsertDto bookDto)
        {
            BookDto = bookDto;
        }
    }
}
