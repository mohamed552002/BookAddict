using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace DataRepository.Core.DTOS.AuthorDtos
{
    public class AuthorInDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), ValidateNever]
        public IFormFile ImageFile { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), ValidateNever]
        public string ImageUrl { get; set; }
    }
}
