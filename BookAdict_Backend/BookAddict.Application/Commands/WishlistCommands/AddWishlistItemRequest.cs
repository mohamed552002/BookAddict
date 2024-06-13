using BookAddict.Application.DTOS.WishlistDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Commands.WishlistCommands
{
    public class AddWishlistItemRequest : IRequest<bool>
    {
        public AddWishlistItemRequest(AddWishlistItemDto addWishlistItemDto)
        {
            AddWishlistItemDto = addWishlistItemDto;
        }

        public AddWishlistItemDto AddWishlistItemDto { get; set; }
    }
}
