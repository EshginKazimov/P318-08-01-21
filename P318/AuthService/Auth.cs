using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthService.Contracts;
using AuthService.Models;
using DomainModel.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthService
{
    public class Auth : IAuth
    {
        private readonly JwtSetting _jwtSetting;
        private readonly List<User> _users;

        public Auth(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
            _users = new List<User>
            {
                new User {Id = 1, Username = "Rail", Password = "123"},
                new User {Id = 2, Username = "Fagan", Password = "123"},
                new User {Id = 3, Username = "Malika", Password = "123"},
            };
        }

        public string GetToken(CredentialModel model)
        {
            var user = _users.Find(x => x.Username == model.Username);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            if (user.Password != model.Password)
            {
                throw new Exception("Invalid credentials");
            }

            var jwtSecurityToken = CreateJwtToken(user);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }

        private JwtSecurityToken CreateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                //new Claim("roles", "Admin"),
                new Claim("roles", "Member"),
                new Claim("username", user.Username)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(_jwtSetting.Issuer, _jwtSetting.Audience, 
                claims, expires: DateTime.UtcNow.AddMinutes(_jwtSetting.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
