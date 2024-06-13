using BookAddict.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookAddict.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MinLength(1), MaxLength(128)]
        public string Name { get; set; }
        [Required, MinLength(4)]
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Book> Books { get; set; }
    }
}