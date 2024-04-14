using BookAdict.Commands.CartCommands;
using BookAdict.Queries.CartQueries;
using DataRepository.Core.Dtos.CartDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase 
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IMediator _mediator;

        public CartController(IMemoryCache memoryCache, IMediator mediator)
        {
            _memoryCache = memoryCache;
            _mediator = mediator;
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody]CartItem cartItem)
        {
            var command = new AddToCartRequest(cartItem);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("GetCart/{UserId}")]
        public async Task<IActionResult> GetCart(string UserId)
        {
            var result = await _mediator.Send(new GetCartQuery(UserId));
            return result.Count() > 0 ? Ok(result) : NoContent();
        }
        [HttpDelete("DeleteCartItem")]
        public async Task<IActionResult> DeleteCartItem([FromBody] CartItem cartItem)
        {
            var result = await _mediator.Send(new DeleteCartItemRequest(cartItem));
            return result ? Ok(cartItem) : BadRequest("There was a problem");
        }
    }
}
