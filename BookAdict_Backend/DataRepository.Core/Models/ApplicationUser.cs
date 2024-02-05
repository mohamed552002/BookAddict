using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required, MinLength(2) , MaxLength(128)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(128)]
        public string Lastname { get; set; }
    }
}
