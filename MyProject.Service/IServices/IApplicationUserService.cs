using MyProject.Data.Entities;

namespace MyProject.Service.IServices
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUser>> GetUserList();
        Task<ApplicationUser> GetUserById(string userId);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<bool> IsExistPhone(string Phone);
        Task<bool> IsExistEmail(string Email);
        Task<bool> IsExistUser();

        Task<bool> UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        Task<string> GenerateToken(ApplicationUser user);
        Task<string> GenerateRefreshToken(ApplicationUser user);

    }
}
