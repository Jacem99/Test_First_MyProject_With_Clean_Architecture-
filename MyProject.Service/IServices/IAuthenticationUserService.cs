using MyProject.Data.Entities;

namespace MyProject.Service.IServices
{
    public interface IAuthenticationUserService
    {
        Task<string> GetJwtToken(ApplicationUser user);
    }
}
