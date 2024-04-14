using BookAdict.Commands.CartCommands;
using DataRepository.Core.Dtos.CartDtos;
using DataRepository.Core.Interfaces;
using MediatR;

namespace BookAdict.Handlers.CartHandler
{
    public class AddToCartHandler : BaseCartHandler , IRequestHandler<AddToCartRequest, IEnumerable<CartItem>>
    {
        public AddToCartHandler(IUnitOfWork unitOfWork):base(unitOfWork) { }

        public async Task<IEnumerable<CartItem>> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.cartServices.AddToCart(request.CartItem);
        }
    }
}
