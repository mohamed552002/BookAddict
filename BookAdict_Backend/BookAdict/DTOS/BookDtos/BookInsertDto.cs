using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DataRepository.Core.DTOS.BookDtos
{
    public class BookInsertDto
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
        [ValidateNever]
        public string ImgUrl { get; set; }
        [ValidateNever]
        public IFormFile ImgFile { get; set; }
        public List<int> AuthorsIds { get; set; }
        public int CategoryId { get; set; }
    }
}
