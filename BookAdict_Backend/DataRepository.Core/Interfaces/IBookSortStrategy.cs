using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Interfaces
{
    public interface IBookSortStrategy
    {
        public Task<IEnumerable<Book>> SortBookAsync(string? categoryName = null);
    }
}
