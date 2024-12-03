using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Service.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // Getting 

        public async Task<ApplicationUser> GetUserByEmail(string email)
         => await _userManager.FindByEmailAsync(email);

        public async Task<ApplicationUser> GetUserById(string userId)
            => await _userManager.FindByIdAsync(userId);

        public async Task<List<ApplicationUser>> GetUserList()
             => await _userManager.Users.AsNoTracking().ToListAsync();


        // Existing 
        public async Task<bool> IsExistUser()
       => await _userManager.Users.AnyAsync();
        public async Task<bool> IsExistEmail(string Email)
        => await _userManager.Users.AnyAsync(u => u.Email == Email);

        public async Task<bool> IsExistPhone(string Phone)
        => await _userManager.Users.AnyAsync(u => u.PhoneNumber == Phone);



        // Operation 
        public async Task DeleteUser(ApplicationUser user)
        => await _userManager.DeleteAsync(user);
        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            var resultAdd = await _userManager.UpdateAsync(user);
            if (resultAdd.Succeeded) return true;
            return false;
        }


        // Token

        public Task<string> GenerateRefreshToken(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateToken(ApplicationUser user)
        {


            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> FilterGetStudentPaginatedQueryable(string names = null)
        {
            var userQueryable = _userManager.Users.AsNoTracking().AsQueryable();
            return userQueryable.Where(u => u.FullName.Contains(names));
        }


    }
}
