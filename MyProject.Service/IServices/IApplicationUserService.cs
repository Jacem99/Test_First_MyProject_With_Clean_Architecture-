using MyProject.Data.Entities;

namespace MyProject.Service.IServices
{
    public interface IApplicationUserService
    {
        // Getting 
        Task<List<ApplicationUser>> GetUserList();
        Task<ApplicationUser> GetUserById(string userId);
        Task<ApplicationUser> GetUserByEmail(string email);
        IQueryable<ApplicationUser> FilterGetStudentPaginatedQueryable(string names);

        // Existing 
        Task<bool> IsExistPhone(string Phone);
        Task<bool> IsExistEmail(string Email);
        Task<bool> IsExistUser();

        // Operations 
        Task<bool> UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);

        // Token

        Task<string> GenerateToken(ApplicationUser user);
        Task<string> GenerateRefreshToken(ApplicationUser user);

    }
}
