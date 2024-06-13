using BookAddict.Application.DTOS.CartDtos;
using MediatR;

namespace BookAdict.Commands.CartCommands
{
    public class AddToCartRequest : IRequest<IEnumerable<CartItem>>
    {
        public CartItem CartItem { get; }

        public AddToCartRequest(CartItem cartItem)
        {
            CartItem = cartItem;
        }
    }
}
