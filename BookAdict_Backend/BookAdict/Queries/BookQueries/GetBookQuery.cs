using DataRepository.Core.DTOS.BookDtos;
using MediatR;

namespace BookAdict.Queries.BookQueries
{
    public class GetBookQuery:IRequest<BookDto>
    {
        public int BookId { get; }
        public GetBookQuery(int bookId)
        {
            BookId = bookId;
        }
    }
}
