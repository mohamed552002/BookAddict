using BookAddict.Application.DTOS.WishlistDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Queries.WishlistQueries
{
    public class GetAllWishlistItemsRequest :IRequest<IEnumerable<GetWishlistItemDto>>
    {
        public string UsertId { get; }

        public GetAllWishlistItemsRequest(string usertId)
        {
            UsertId = usertId;
        }
    }
}
