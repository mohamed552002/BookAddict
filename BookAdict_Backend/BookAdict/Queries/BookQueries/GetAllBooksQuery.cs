using DataRepository.Core.DTOS.BookDtos;
using MediatR;

namespace BookAdict.Queries.BookQueries
{
    public class GetAllBooksQuery:IRequest<IEnumerable<BookDto>>
    {

    }
}
