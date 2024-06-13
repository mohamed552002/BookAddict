using BookAddict.Application.DTOS.AuthDtos;
using BookAddict.Domain.Models;
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
