using Microsoft.AspNetCore.Mvc;
using BookAddict.Application.DTOS.CartDtos;
using MediatR;
using BookAdict.Queries.OrderQueries;
using BookAddict.Application.Queries.OrderQueries;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder([FromBody]IEnumerable<CartItem> items , [FromQuery]bool IsCashPayment, [FromQuery] string userId)
        {
            var query = new ConfirmOrderRequest(items, IsCashPayment, userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [Route("ConfirmPayment")]
        [HttpGet]
        public async Task<IActionResult> ConfirmPayment()
        {
            var query = new RedirectOrderCreditCardPaymentRequest();
            var result = await _mediator.Send(query);
            return Redirect(result);
        }
    }
}
