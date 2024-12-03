using Microsoft.IdentityModel.Tokens;
using MyProject.Data.Entities;
using MyProject.Data.Helper;
using MyProject.Service.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyProject.Service.Services
{
    public class AuthenticationUserService : IAuthenticationUserService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationUserService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public Task<string> GetJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(user.Email),user.Email),
                new Claim(nameof(user.UserName),user.UserName),
                new Claim(nameof(user.FullName),user.FullName),

            };

            var AccessToken = new JwtSecurityToken(

                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(AccessToken);
            return Task.FromResult(token);
        }
    }
}
