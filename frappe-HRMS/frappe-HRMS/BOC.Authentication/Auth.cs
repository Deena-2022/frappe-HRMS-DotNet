using Azure.Core;
using BOC.Authentication.Interface;
using BOC.Domain.DataEntity;
using Database.MSSQL.Context;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace BOC.Authentication
{
    public class Auth : IJWTAuth
    {
        private readonly string key;
        private readonly BOCContext context;

        public Auth(string key, BOCContext context)
        {
            this.key = key;
            this.context = context;
        }
        public string Authentication(string username, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == username && x.Password == password);
            if (user == null)
            {
                 throw new AuthenticationException("Invalid credentials provided.");
            }

            var authClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var token = CreateToken(authClaims);
            var result  = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("25E8A7A58A9EE040EB651692F12D8B3A0B3D952DF04B54C8DE125C8E0155A9F6"));
            _ = int.TryParse("1", out int tokenValidityInDays);

            var token = new JwtSecurityToken(
                issuer: "true",
                audience: "true",
                expires: DateTime.Now.AddDays(tokenValidityInDays),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}