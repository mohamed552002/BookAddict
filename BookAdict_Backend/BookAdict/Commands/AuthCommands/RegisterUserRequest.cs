using DataRepository.Core.Dtos;
using DataRepository.Core.Models;
using MediatR;

namespace BookAdict.Commands.AuthCommands
{
    public class RegisterUserRequest : IRequest<AuthModel>
    {
        public RegisterRequestDto RegisterRequest { get; }
        public RegisterUserRequest(RegisterRequestDto registerRequest)
        {
            RegisterRequest = registerRequest;
        }
    }
}
