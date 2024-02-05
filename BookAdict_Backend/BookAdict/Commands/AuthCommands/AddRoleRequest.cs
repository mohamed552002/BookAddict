using DataRepository.Core.Dtos;
using MediatR;

namespace BookAdict.Commands.AuthCommands
{
    public class AddRoleRequest : IRequest<string>
    {
        public readonly AddRoleDto _roleDto;
        public AddRoleRequest(AddRoleDto roleDto) {
            _roleDto = roleDto;
        }
    }
}
