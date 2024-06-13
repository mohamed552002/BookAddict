using BookAddict.Application.DTOS.AuthorDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Queries.AuthorQueries
{
    public class SearchAuthorsRequest : IRequest<IEnumerable<AuthorDto>>
    {
        public string SearchText { get; }
        public SearchAuthorsRequest(string searchText)
        {
            SearchText = searchText;
        }
    }
}
