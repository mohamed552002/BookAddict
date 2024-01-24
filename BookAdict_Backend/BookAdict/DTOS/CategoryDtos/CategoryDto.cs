using DataRepository.Core.DTOS.BookDtos;
using DataRepository.Core.Models;
using System.Text.Json.Serialization;

namespace DataRepository.Core.DTOS.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public virtual ICollection<BookDto> Books { get; set; }
    }
}
