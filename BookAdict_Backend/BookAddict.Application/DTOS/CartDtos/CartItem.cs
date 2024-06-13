using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.CartDtos
{
    
    public class CartItem
    {
        [Required]
        public int BookId { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public double SinglePrice { get; set; }
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; } = 1;
        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
