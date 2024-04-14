using DataRepo.Ef;
using DataRepository.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Core.CustomValdiationAttributes
{
    public class IsUniqueAttribute : ISUniqueAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            return _context.Books.SingleOrDefault(b => b.ISPN == value) == null ? new ValidationResult("There is already book with this ISBN") : ValidationResult.Success  ;
        }
    }
}
