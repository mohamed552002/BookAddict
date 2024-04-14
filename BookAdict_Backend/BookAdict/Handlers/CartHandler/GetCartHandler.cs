using BookAdict.Queries.CartQueries;
using DataRepository.Core.Dtos.CartDtos;
using DataRepository.Core.Interfaces;
using MediatR;

namespace BookAdict.Handlers.CartHandler
{
    public class GetCartHandler : BaseCartHandler, IRequestHandler<GetCartQuery, IEnumerable<CartItem>>
    {
        public GetCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Task<IEnumerable<CartItem>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitOfWork.cartServices.GetCart(request.UsertId));
        }
    }
}
