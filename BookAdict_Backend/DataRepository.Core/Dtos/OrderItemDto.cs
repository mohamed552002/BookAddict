using DataRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataRepository.Core.Dtos
{
    public class OrderItemDto
    {
        [Required]
        public int BookId { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Total price must be more than 0")]
        public int Qyantity { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Total price must be more than 0")]
        public int SinglePrice { get; set; }
    }
}
