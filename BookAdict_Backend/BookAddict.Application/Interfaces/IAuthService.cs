using BookAddict.Application.DTOS.AuthDtos;
using BookAddict.Domain.Models;

namespace BookAddict.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthModel> RegisterAsync(RegisterRequestDto registerModel);
        public Task<AuthModel> GetTokenasync(TokenRequestDto tokenRequestModel);
        public Task<string> AddRoleAsync(AddRoleDto roleDto);
    }
}
