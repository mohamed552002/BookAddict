using AutoMapper;
using BookAdict.Queries.OrderQueries;
using BookAdict.Services;
using BookAddict.Application.DTOS.CartDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using BookAddict.Application.DTOS.OrderAndPaymentDtos;

namespace BookAdict.Handlers.OrderHandlers
{
    public class ConfirmOrderRequestHandler : IRequestHandler<ConfirmOrderRequest, ConfirmPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaymentService _paymentService;
        private readonly IMemoryCache _cache;
        public ConfirmOrderRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, PaymentService paymentService, IMemoryCache cache)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            _cache = cache;
        }

        public async Task<ConfirmPaymentResponse> Handle(ConfirmOrderRequest request, CancellationToken cancellationToken)
        {
            var orderItems = _mapper.Map<IEnumerable<OrderItem>>(request.Items);
            await HandleOrderItemsBooks(orderItems);

            if (request.IsCashPayment) {
               await CreateAndHandleOrder(request.userId,orderItems);
                _cache.Remove($"Cart{request.userId}");
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
