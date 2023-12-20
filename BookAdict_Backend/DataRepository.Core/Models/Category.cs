using System.ComponentModel.DataAnnotations;

namespace DataRepository.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required,MinLength(1),MaxLength(128)]
        public string Name { get; set; }
        [Required, MinLength(4), MaxLength(512)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}