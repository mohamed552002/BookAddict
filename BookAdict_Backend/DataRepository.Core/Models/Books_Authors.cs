using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Models
{
    public class Books_Authors
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public virtual Book Books { get; set; }
        public virtual Author Author { get; set; }
    }
}
