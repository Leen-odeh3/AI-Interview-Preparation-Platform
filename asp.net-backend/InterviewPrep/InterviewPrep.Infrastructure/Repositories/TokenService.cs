using InterviewPrep.Core.Entities;
using InterviewPrep.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InterviewPrep.Infrastructure.Repositories;
public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly JWT _jwt;

    public TokenService(UserManager<User> userManager, IOptions<JWT> jwt)
    {
        _userManager = userManager;
        _jwt = jwt.Value;
    }
    public async Task<JwtSecurityToken> CreateJwtTokenAsync(User user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("FirstName", user.FirstName),
        new Claim("LastName", user.LastName)
            }
        .Union(userClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwt.DurationInDays),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }

}
