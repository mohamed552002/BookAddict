using DataRepository.Core.Dtos;
using MediatR;

namespace BookAdict.Queries.OrderQueries
{
    public class ConfirmOrderRequest:IRequest<ConfirmPaymentResponse>
    {
        public ConfirmOrderRequest(IEnumerable<OrderItemDto> items, bool isCashPayment, string userId)
        {
            Items = items;
            IsCashPayment = isCashPayment;
            this.userId = userId;
        }

        public IEnumerable<OrderItemDto> Items { get; }
        public bool IsCashPayment { get; }
        public string userId { get; }
    }
}
