using BookAdict.Commands.AuthCommands;
using DataRepository.Core.Dtos;
using DataRepository.Core.Interfaces;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Handlers.AuthHandler
{
    public class RegisterUserHandler :AuthBaseHandler, IRequestHandler<RegisterUserRequest, AuthModel>
    {
        public RegisterUserHandler(IAuthService authService):base(authService) { }


        public async Task<AuthModel> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsync(request.RegisterRequest);
            return result;
        }
    }
}
