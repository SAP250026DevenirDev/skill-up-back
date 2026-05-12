namespace SkillUp.API.Dtos.Responses
{
    public class AddSkillToProfileResponseDto
    {
        public Guid SkillId { get; set; }
        public string SkillName { get; set; } =null!;
        public int Level { get; set; }
        public string CategoryName { get; set; } =null!;

        public DateTime LastUpdate { get; set; }
    }
}
