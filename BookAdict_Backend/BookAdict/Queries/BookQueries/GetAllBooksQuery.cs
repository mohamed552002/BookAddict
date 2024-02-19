using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Queries.BookQueries
{
    public class GetAllBooksQuery:IRequest<IEnumerable<BookDto>>
    {
        public string? SortBy { get; }
        public string? CategoryName { get; }
        public GetAllBooksQuery(string? sortBy, string? categoryName)
        {
            SortBy = sortBy;
            CategoryName = categoryName;
        }
    }
}
