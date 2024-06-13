using BookAddict.Application.DTOS.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.CartDtos
{
    public class Cart
    {
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUserDto User { get; set; }
    }
}
