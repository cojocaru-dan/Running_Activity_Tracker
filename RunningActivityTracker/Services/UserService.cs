using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RunningActivityTracker.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace RunningActivityTracker.Services
{
    public class UserService : IUserService
    {
        public List<UserEntityWithToken> usersRepo = new();
        private readonly JWTSettings _jwtSettings;

        public UserService(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
        public UserEntityWithToken FindCurrentUser() 
        {
            return usersRepo[^1];
        }
        public UserEntityWithToken CreateUser(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userEntityWithToken = new UserEntityWithToken
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Roles = user.Roles,
                Token = tokenHandler.WriteToken(token)
            };
            usersRepo.Add(userEntityWithToken);
            return userEntityWithToken;
        }
        public Task<UserEntityWithToken> AuthenticateAsync(string userName, string password)
        {
            var user = usersRepo.Where(u => u.Username == userName && u.Password == password).FirstOrDefault();
            return Task.FromResult(user);
        }
        public IEnumerable<UserEntityWithToken> GetAll()
        {
            return usersRepo;
        }
    }
}