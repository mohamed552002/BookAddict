using AutoMapper;
using BookAdict.Queries.OrderQueries;
using BookAdict.Services;
using DataRepository.Core.Dtos;
using DataRepository.Core.Dtos.CartDtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Handlers.OrderHandlers
{
    public class ConfirmOrderRequestHandler : IRequestHandler<ConfirmOrderRequest, ConfirmPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaymentService _paymentService;
public ConfirmOrderRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, PaymentService paymentService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }

        public async Task<ConfirmPaymentResponse> Handle(ConfirmOrderRequest request, CancellationToken cancellationToken)
        {
            var orderItems = _mapper.Map<IEnumerable<OrderItem>>(request.Items);
            await HandleOrderItemsBooks(orderItems);

            if (request.IsCashPayment) {
               await CreateAndHandleOrder(request.userId,orderItems);
                return (new ConfirmPaymentResponse());
            }
            var user = await _unitOfWork.User.GetUser(request.userId);
            return new ConfirmPaymentResponse(_paymentService.CheckOut(new CheckOutRequestDto(user, orderItems)), orderItems);
        }
        private async Task CreateAndHandleOrder(string UserId, IEnumerable<OrderItem> orderItems)
        {
            Order order = new Order(UserId, orderItems);
            await _unitOfWork.Order.AddOrder(order);
        }
        private async Task HandleOrderItemsBooks(IEnumerable<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                item.Book = await _unitOfWork.Books.GetBookAsync(item.BookId);
            }
        }
    }
}
