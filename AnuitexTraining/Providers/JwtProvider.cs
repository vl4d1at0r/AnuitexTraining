using AnuitexTraining.BusinessLogicLayer.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.PresentationLayer.Providers
{
    public class JwtProvider
    {
        private TokenValidationParameters _expiredTokenValidationParameters;
        public SymmetricSecurityKey SymmetricSecurityKey;

        public JwtProvider()
        {
            SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.Key));
            _expiredTokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = AuthOptions.Audience,
                ValidateLifetime = false,
                IssuerSigningKey = SymmetricSecurityKey,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        public string GenerateAccessToken(UserModel userModel, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("Id" , userModel.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userModel.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(1),
                claims: claims,
                signingCredentials: new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public JwtSecurityToken GetValidatedExpiredAccessToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            tokenHandler.ValidateToken(accessToken, _expiredTokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return jwtSecurityToken;
        }
    }
}
