using DataRepository.Core.Dtos;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Queries.AuthQueries
{
    public class GetAllUsersRequest : IRequest<IEnumerable<ApplicationUserDto>>
    {

    }
}
