using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IBookRepo Books { get; }
        public void OnComplete();
        public void ActionOnComplete();
    }
}
