using BookAdict.Commands.AuthCommands;
using DataRepository.Core.Interfaces;
using MediatR;

namespace BookAdict.Handlers.AuthHandler
{
    public class AddRoleHandler : AuthBaseHandler, IRequestHandler<AddRoleRequest, string>
    {
        public AddRoleHandler(IAuthService authService):base(authService)
        {
            
        }
        public async Task<string> Handle(AddRoleRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.AddRoleAsync(request._roleDto);
            return result;
        }
    }
}
