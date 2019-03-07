using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Extensions;
using hostingRatingWebApi.Handlers.Interfaces;
using hostingRatingWebApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace hostingRatingWebApi.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IConfiguration _configuration;
        public JwtHandler(IConfiguration configuration){
            _configuration = configuration;
        }
        public JwtDTO CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var jwtExpiry = _configuration["JwtExpireDays"];
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim("Role", role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,now.Ticks.ToString())

            };
            var expires = now.AddMinutes(Double.Parse(jwtExpiry));
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"])),
                SecurityAlgorithms.HmacSha256
            );
            var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtIssuer"],
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtDTO{
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}