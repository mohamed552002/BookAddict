using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.OrderAndPaymentDtos
{
     public class ConfirmPaymentResponse
    {
        public ConfirmPaymentResponse() { }
        public ConfirmPaymentResponse(string payementLink, IEnumerable<OrderItem> items)
        {
            PayementLink = payementLink;
            Items = items;
        }

        public string PayementLink { get; set; }
        public IEnumerable<OrderItem> Items { get;}
        public string Message { get; set; }
    }
}
