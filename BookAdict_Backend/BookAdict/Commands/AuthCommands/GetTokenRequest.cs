using DataRepository.Core.Dtos;
using DataRepository.Core.Models;
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
