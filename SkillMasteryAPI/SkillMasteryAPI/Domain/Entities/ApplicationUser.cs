using Microsoft.AspNetCore.Identity;

namespace SkillMasteryAPI.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
