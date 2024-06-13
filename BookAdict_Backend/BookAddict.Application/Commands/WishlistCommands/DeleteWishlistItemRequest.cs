using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Commands.WishlistCommands
{
    public class DeleteWishlistItemRequest : IRequest<bool>
    {
        public DeleteWishlistItemRequest(int bookId, string userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public int BookId { get; }
        public string UserId { get; }
    }
}
