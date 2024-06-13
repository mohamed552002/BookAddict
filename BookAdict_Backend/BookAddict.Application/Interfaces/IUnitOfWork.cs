using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IBookRepo Books { get; }
        ICategoryRepo Category { get; }
        IAuthorRepo Author { get; }
        ICartServices cartServices { get; }
        IUserRepo User { get; }
        IOrderServices Order { get; }
        public void OnComplete();
        public void ActionOnComplete();
    }
}
