using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthenticationSample.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationSample.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var signingCredentials = new SigningCredentials(JwtHelpers.Key,
                SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "user@example.com"),
                new Claim(ClaimTypes.Role, "Administrator")
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "http://localhost:54335/",
                Issuer = "http://localhost:54335/",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return Ok($"Bearer {signedAndEncodedToken}");
        }
    }
}
