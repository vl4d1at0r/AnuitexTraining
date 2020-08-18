using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.PresentationLayer.Helpers
{
    public static class JwtHelper
    {
        public static SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.Key));

        public static string GenerateAccessToken(ApplicationUser user)
        {
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: DateTime.Now,
                claims: new Claim[] { new Claim(JwtRegisteredClaimNames.Sub, user.UserName), new Claim(JwtRegisteredClaimNames.Email, user.Email), new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
