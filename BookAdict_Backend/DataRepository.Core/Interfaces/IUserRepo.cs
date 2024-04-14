using DataRepository.Core.Dtos;
using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Interfaces
{
    public interface IUserRepo
    {
        public Task<ApplicationUser> GetUser(string id);
        public Task<IEnumerable<ApplicationUser>> GetAllUsers();
        public Task<bool> IsUserExist(string id);
    }
}
