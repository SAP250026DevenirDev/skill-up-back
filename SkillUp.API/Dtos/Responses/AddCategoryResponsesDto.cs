namespace SkillUp.API.Dtos.Responses
{
    public class AddCategoryResponsesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public DateOnly CreatedAt { get; set; }
    }
}
