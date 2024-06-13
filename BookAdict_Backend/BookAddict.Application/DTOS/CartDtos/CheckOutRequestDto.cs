using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.CartDtos
{
    public class CheckOutRequestDto
    {
        public CheckOutRequestDto(ApplicationUser applicationUser, IEnumerable<OrderItem> orderItems)
        {
            ApplicationUser = applicationUser;
            OrderItems = orderItems;
        }

        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
