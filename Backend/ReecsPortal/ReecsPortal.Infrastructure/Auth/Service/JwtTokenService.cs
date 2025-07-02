using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ReecsPortal.Application.Interfaces;
using ReecsPortal.Domain.Entities;
using ReecsPortal.Infrastructure.DTradeModels;



namespace ReecsPortal.Infrastructure.Identity.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration config;
        private readonly SymmetricSecurityKey _key;
        private readonly ILogger _logger;

        public JwtTokenService(IConfiguration config, ILogger<JwtTokenService> logger)
        {
            this.config = config;
            _logger = logger;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));
        }

        public async Task<string> CreateTokenAsync(TblUser user)
        {
            
            if (user == null)
                throw new ArgumentException("Invalid user type for token creation");

            var issuer = config["JWT:Issuer"];
            var audience = config["JWT:Audience"];

            _logger.LogInformation("ContactEmail: {Email}, Name: {Name}", user.ContactEmail, user.Name);

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username cannot be null or empty for token claims");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Name ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username ?? string.Empty),


            };

            

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = issuer,
                Audience = audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}