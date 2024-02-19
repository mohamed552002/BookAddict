using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required,MinLength(2),MaxLength(128)]
        public string Name { get; set; }
        [Required, MinLength(4)]
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Books_Authors> Books { get; set; }
    }
}
