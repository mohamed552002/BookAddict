using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

using DataRepository.Core.Interfaces;

namespace DataRepository.Core.Models
{
    [Index(nameof(ISPN),IsUnique =true)]
    public class Book
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(128), ISUnique()]
        public string ISPN { get; set; }
        [Required,MinLength(2),MaxLength(128)]
        public string Title { get; set; }
        [Required, MinLength(4)]
        public string Description { get; set; }
        [Required,Range(0,double.MaxValue)]
        public double Price { get; set; }
        //public int AuthorId { get; set; }
        [Required]
        public DateTime AddedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int numberOfSales {  get; set; } = 0;
        [Required,Range(0,int.MaxValue)]
        public int AvailableInStock { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get;set; }
        public virtual ICollection<Books_Authors> Authors { get; set; }
        public virtual Category Category { get; set; }


    }
}
