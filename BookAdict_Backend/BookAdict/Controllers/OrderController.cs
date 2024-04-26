using BookAdict.Services;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using DataRepository.Core.Dtos.CartDtos;
using DataRepository.Core.Dtos;
using AutoMapper;
using MediatR;
using BookAdict.Queries.OrderQueries;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly PaymentService _paymentService;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public OrderController( IMediator mediator)
        {
            //_paymentService = paymentService;
            //_unitOfWork = unitOfWork;
            //_mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder([FromBody]IEnumerable<OrderItemDto> items , [FromQuery]bool IsCashPayment, [FromQuery] string userId)
        {
            var query = new ConfirmOrderRequest(items, IsCashPayment, userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
