namespace SkillMasteryAPI.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
    }
}
