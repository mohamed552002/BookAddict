using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.DTOS.AuthDtos
{
    public class AddRoleDto
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
