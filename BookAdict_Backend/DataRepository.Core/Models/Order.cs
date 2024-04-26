using DataRepository.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataRepository.Core.Models
{
    public class Order
    {
        public Order() { }

        public Order(string UserId,IEnumerable<OrderItem> Items) 
        {
            this.UserId = UserId;
            TotalPrice = Items.Sum(item => item.SinglePrice * item.Qyantity);
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeliverd { get; set; } = false;
        [DateChecker(ErrorMessage = "Date Is Wrong")]
        [DataType(DataType.Date)]
        public DateTime DeliverdAt { get; set; } = default(DateTime);
        [Required]
        public float TotalPrice { get; set; }
        [Required]
        public bool IsPaid { get; set; } = false;
        public virtual ApplicationUser User { get; set; }
        [JsonIgnore]
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
