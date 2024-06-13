using BookAddict.Application.DTOS.BookDtos;
using MediatR;

namespace BookAdict.Queries.BookQueries
{
    public class GetByCategoryQuery : IRequest<IEnumerable<BookDto>>
    {
        public int CategoryId {get;}

        public GetByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
