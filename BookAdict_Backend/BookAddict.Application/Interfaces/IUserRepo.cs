using BookAddict.Domain.Models;

namespace BookAddict.Application.Interfaces
{
    public interface IUserRepo
    {
        public Task<ApplicationUser> GetUser(string id);
        public Task<IEnumerable<ApplicationUser>> GetAllUsers();
        public Task<bool> IsUserExist(string id);
    }
}
