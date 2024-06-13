using BookAddict.Application.DTOS.UserDtos;
using BookAddict.Domain.Models;
using MediatR;

namespace BookAdict.Queries.AuthQueries
{
    public class GetAllUsersRequest : IRequest<IEnumerable<ApplicationUserDto>>
    {

    }
}
