using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataRepository.Core.DTOS.AuthorDtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public ICollection<BookDto> Books { get; set; }
    }
}
