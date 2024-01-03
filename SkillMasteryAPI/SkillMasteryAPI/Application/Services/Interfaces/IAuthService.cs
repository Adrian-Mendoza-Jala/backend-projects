using Microsoft.AspNetCore.Identity;
using SkillMasteryAPI.Domain.Entities;

namespace SkillMasteryAPI.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterModel model);
        Task<string> LoginUserAsync(LoginModel model);
    }
}
