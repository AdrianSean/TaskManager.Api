using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CreateJWT
{
    internal class Program
    {
        private const string SymmetricKey = "cXdlcnR5dWlvcGFzZGZnaGprbHp4Y3Zibm0xMjM0NTY=";

        static void Main(string[] args)
        {
            var key = Convert.FromBase64String(SymmetricKey);           
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "bhogg"),
                    new Claim(ClaimTypes.GivenName, "Boss"),
                    new Claim(ClaimTypes.Surname, "Hogg"),
                    new Claim(ClaimTypes.Role, "Manager"),
                    new Claim(ClaimTypes.Role, "SeniorWorker"),
                    new Claim(ClaimTypes.Role, "JuniorWorker")
                }),

                Audience = "http://www.example.com",
                Issuer = "corp",
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddYears(10)
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            Console.WriteLine(tokenString);
            Debug.WriteLine(tokenString);
            Console.ReadLine();

        }
    }
}
