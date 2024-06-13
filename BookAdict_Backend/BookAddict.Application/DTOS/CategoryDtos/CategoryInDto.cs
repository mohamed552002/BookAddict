namespace BookAdict.Application.DTOS.CategoryDtos
{
    public class CategoryInDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
