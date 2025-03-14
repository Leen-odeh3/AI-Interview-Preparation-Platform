using InterviewPrep.Core.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace InterviewPrep.Core.Interfaces;
public interface ITokenService
{
    Task<JwtSecurityToken> CreateJwtTokenAsync(User user);
}
