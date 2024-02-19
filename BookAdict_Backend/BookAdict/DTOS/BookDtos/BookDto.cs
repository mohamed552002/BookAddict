using DataRepository.Core.DTOS.AuthorDtos;
using DataRepository.Core.DTOS.CategoryDtos;
using DataRepository.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataRepository.Core.DTOS.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public int ISPN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int numberOfSales { get; set; } = 0;
        public int AvailableInStock { get; set; }
        public string ImageUrl { get; set; }
        public FormFile ImgFile { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<AuthorDto> Authors { get; set; }
        public CategoryDto Category { get; set; }

    }
}
