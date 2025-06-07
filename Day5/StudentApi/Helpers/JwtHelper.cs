using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StudentApi.Models;

namespace StudentApi.Helpers;

public static class JwtHelper
{
    public static string GenerateToken(Student student, IConfiguration config)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, student.FullName),
            new Claim(ClaimTypes.Email, student.Email),
        };

        var key = config["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key", "JWT key is not configured.");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
