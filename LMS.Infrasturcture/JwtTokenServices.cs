using LMSAPI.Domain.Interface;
using LMSP.Domain.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrasturcture
{
    public class JwtTokenServices : ITokens
    {
        private readonly IConfiguration _configuration;
        public JwtTokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Users user)
        {
            var claims = new[] {
             new Claim(ClaimTypes.Name, user.Name),
             new Claim(ClaimTypes.Email, user.Email),
             new Claim(ClaimTypes.Role,  user.UserTypeID.ToString())
            };

            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                
                 issuer: _configuration["Jwt:Issuer"],
                 audience: _configuration["Jwt:Audience"],
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                 signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
