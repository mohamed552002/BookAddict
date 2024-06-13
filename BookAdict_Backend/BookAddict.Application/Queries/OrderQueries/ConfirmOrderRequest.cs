
using BookAddict.Application.DTOS.CartDtos;
using MediatR;
using BookAddict.Application.DTOS.OrderAndPaymentDtos;

namespace BookAdict.Queries.OrderQueries
{
    public class ConfirmOrderRequest:IRequest<ConfirmPaymentResponse>
    {
        public ConfirmOrderRequest(IEnumerable<CartItem> items, bool isCashPayment, string userId)
        {
            Items = items;
            IsCashPayment = isCashPayment;
            this.userId = userId;
        }

        public IEnumerable<CartItem> Items { get; }
        public bool IsCashPayment { get; }
        public string userId { get; }
    }
}
