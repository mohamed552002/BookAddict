using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Core.Models
{
    [Index(nameof(ISPN),IsUnique =true)]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public int ISPN { get; set; }
        [Required,MinLength(2),MaxLength(128)]
        public string Title { get; set; }
        [Required, MinLength(4), MaxLength(256)]
        public string Description { get; set; }
        [Required,Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        //public int AuthorId { get; set; }
        [Required]
        public DateTime AddedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int numberOfSales {  get; set; } = 0;
        [Required,Range(0,int.MaxValue)]
        public int AvailableInStock { get; set; }
        public string ImageUrl { get; set; }

    }
}
