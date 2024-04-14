using DataRepository.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Core.CustomAttributes
{
    //public class ISUniqueAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //    {
    //        IDBContext context = new Application ;
    //        var _context = context.GetDbContext();
    //        return _context.Books.SingleOrDefault(b => b.ISPN == value) == null ? new ValidationResult("There is already book with this ISBN") : ValidationResult.Success;
    //    }
    //}
}
