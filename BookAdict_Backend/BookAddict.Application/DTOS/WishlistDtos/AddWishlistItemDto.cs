using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.WishlistDtos
{
    public class AddWishlistItemDto
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
    }
}
