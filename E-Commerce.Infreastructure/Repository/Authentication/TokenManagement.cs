using E_Commerce.Domain.Entities.Identity;
using E_Commerce.Domain.Interface;
using E_Commerce.Infreastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_Commerce.Infreastructure.Repository.Authentication
{
    internal class TokenManagement : ITokenManagement
    {
        private readonly AppDbContext context;
        private readonly IConfiguration config;

        public TokenManagement(AppDbContext context,IConfiguration config )
        {
            this.context = context;
            this.config = config;
        }
        public async Task<bool> AddRefreshToken(string userId, string refreshToken)
        {
            context.RefreshTokens.Add(new RefreshToken
            {
                UserId= userId,
                Token = refreshToken
            });
            await context.SaveChangesAsync();
            return true;
        }

        public string generateToken(List<Claim> claim)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(config["JwtSettings:SecretKey"]!));
            var cred=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expiration=DateTime.Now.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: config["JwtSettings:Issuer"],
                audience: config["JwtSettings:Audience"],
                claims: claim,
                expires: expiration,
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetRefreshToken()
        {
            const int byteSize = 64;
            byte[] randomByte=new byte[byteSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomByte);
            }
            return Convert.ToBase64String(randomByte);
        }

        public List<Claim> GetUserClaimsFromToken(string token)
        {
            var tokenHandler=new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            if (jwtToken != null)
                return jwtToken.Claims.ToList();
            return [];
        }

        public async Task<string> GetUserIdRefreshToken(string token)
        {
            return (context.RefreshTokens.FirstOrDefault(t => t.Token == token))!.UserId;

        }

        public async Task<bool> UpdateRefreshToken(string userId, string refreshToken)
        {
           var user=await context.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == userId);
            if (user != null)
            {
                user.Token = refreshToken;
                context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ValidateRefreshToken(string token)
        {
            var user=await context.RefreshTokens.FirstOrDefaultAsync(t=>t.Token == token);
            return user != null;
        }
    }
}
