using BookAdict.Commands.AuthCommands;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Handlers.AuthHandler
{
    public class TokenRequestHandler : AuthBaseHandler, IRequestHandler<GetTokenRequest, AuthModel>
    {
        public TokenRequestHandler( IAuthService authService):base(authService) { }

        public async Task<AuthModel> Handle(GetTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.GetTokenasync(request.TokenRequest);
            return result;
        }
    }
}
