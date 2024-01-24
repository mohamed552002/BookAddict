using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.Models;
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
