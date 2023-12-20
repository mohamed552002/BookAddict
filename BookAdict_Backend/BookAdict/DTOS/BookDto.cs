using DataRepository.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookAdict.DTOS
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
        public ICollection<AuthorDto> Authors { get; set; }
        public string CategoryName { get; set; }
    }
}
