using DataRepository.Core.Dtos.CartDtos;
using MediatR;

namespace BookAdict.Queries.CartQueries
{
    public class GetCartQuery : IRequest<IEnumerable<CartItem>>
    {
        public string UsertId { get;}

        public GetCartQuery(string usertId)
        {
            UsertId = usertId;
        }
    }
}
