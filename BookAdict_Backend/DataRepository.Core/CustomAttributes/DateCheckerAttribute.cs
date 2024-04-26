using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.CustomAttributes
{
    public class DateCheckerAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (DateTime)value > DateTime.Now;
        }
    }
}
