using DataRepository.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookAdict.DTOS
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public ICollection<BookDto> Books { get; set; }
    }
}
