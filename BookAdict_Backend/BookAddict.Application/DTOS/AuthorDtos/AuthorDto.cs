using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookAddict.Application.DTOS.AuthorDtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Message { get; set; } =string.Empty;
        public string ImageUrl { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public ICollection<BookDto> Books { get; set; }
    }
}
