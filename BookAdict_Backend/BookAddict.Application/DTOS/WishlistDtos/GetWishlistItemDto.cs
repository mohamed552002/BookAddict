using BookAddict.Application.DTOS.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.WishlistDtos
{
    public class GetWishlistItemDto
    {
        public int BookId { get; set; }
        public string UserId { get; set; }
        public BookDto Book { get; set; }
    }
}
