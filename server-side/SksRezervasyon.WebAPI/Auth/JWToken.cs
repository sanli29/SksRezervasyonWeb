
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using SksRezervasyon.WebAPI.Auth.Abstract;

namespace SksRezervasyon.WebAPI.Auth
{
    public class JWToken : IJWToken
    {
        private readonly IConfiguration Configuration;
        public JWToken(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }


        public string GenerateJSONWebToken(int id)
        {
            var someClaims = new Claim[]{
                new Claim("Id",id.ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              Configuration["Jwt:Issuer"],
              Configuration["Jwt:Audience"],
              someClaims,
              expires: DateTime.Now.AddMinutes(50),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int GetId(IEnumerable<Claim> claims)
        {
            return Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.InvariantCultureIgnoreCase)).Value);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            var caglar = tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }
    }
}
