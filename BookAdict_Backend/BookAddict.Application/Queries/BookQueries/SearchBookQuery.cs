using BookAddict.Application.DTOS.BookDtos;
using MediatR;

namespace BookAdict.Queries.BookQueries
{
    public class SearchBookQuery:IRequest<IEnumerable<BookDto>>
    {
        public string SearchText {  get;} = string.Empty;

        public SearchBookQuery(string searchText)
        {
            SearchText = searchText;
        }
    }
}
