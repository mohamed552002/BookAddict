using BookAddict.Application.DTOS.AuthDtos;
using BookAddict.Domain.Models;
using MediatR;

namespace BookAdict.Commands.AuthCommands
{
    public class GetTokenRequest : IRequest<AuthModel>
    {
        public TokenRequestDto TokenRequest { get; }
        public GetTokenRequest(TokenRequestDto tokenRequest)
        {
            TokenRequest = tokenRequest;
        }
    }
}
