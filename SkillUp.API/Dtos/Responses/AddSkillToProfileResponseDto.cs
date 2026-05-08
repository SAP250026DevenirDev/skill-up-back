namespace SkillUp.API.Dtos.Responses
{
    public class AddSkillToProfileResponseDto
    {
        public Guid SkillId { get; set; }
        public string? SkillName { get; set; }
        public int Level { get; set; }
        public string? CategoryName { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
