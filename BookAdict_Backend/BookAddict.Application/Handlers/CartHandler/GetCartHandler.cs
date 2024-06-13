using BookAdict.Queries.CartQueries;
using BookAddict.Application.DTOS.CartDtos;
using BookAddict.Application.Interfaces;
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
