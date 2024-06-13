using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookAddict.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        [JsonIgnore]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Quantity must be more than 0")]
        public int Quantity { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Price must be more than 0")]
        public int SinglePrice { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Total price must be more than 0")]
        public int TotalPrice => Quantity * SinglePrice;
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Book Book { get; set; }


    }
}
