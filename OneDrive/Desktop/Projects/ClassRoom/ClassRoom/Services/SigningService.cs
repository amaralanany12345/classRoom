using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ClassRoom.Services
{
    public class SigningService<T> where T : class
    {
        private readonly Jwt _jwt;

        public SigningService(Jwt jwt)
        {
            _jwt = jwt;
        }

        protected string generateJwtToken(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwt.Issuer,
                Audience = _jwt.Audience,
                Expires = DateTime.Now.AddSeconds(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey)),
                SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name,user.userName),
                    new(ClaimTypes.Email,user.email),
                    new(ClaimTypes.NameIdentifier,user.id.ToString()),
                    new(ClaimTypes.Role,user.role.ToString()),
                })

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
        protected string hashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        protected bool verifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
