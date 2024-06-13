using BookAddict.Application.Commands.WishlistCommands;
using BookAddict.Application.DTOS.WishlistDtos;
using BookAddict.Application.Queries.WishlistQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WishlistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddWishlistItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddWishlistItem([FromBody] AddWishlistItemDto addWishlistItemDto)
        {
            var result = await _mediator.Send(new AddWishlistItemRequest(addWishlistItemDto));
            return result ? Ok("Book Added Successfully") : BadRequest();
        }

        [HttpGet("GetWishlist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWishlist([FromQuery] string userId)
        {
            var result = await _mediator.Send(new GetAllWishlistItemsRequest(userId));
            return Ok(result);
        }

        [HttpGet("DeleteWishlistItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWishlistItem([FromQuery] string userId ,[FromQuery] int bookId)
        {
            var result = await _mediator.Send(new DeleteWishlistItemRequest(bookId,userId));
            return result ? Ok("Item deleted successfully") : NotFound("No wishlist items found to delete");
        }
    }
}
