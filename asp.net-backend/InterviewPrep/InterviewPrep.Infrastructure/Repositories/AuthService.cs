using InterviewPrep.Core.DTOs.General;
using InterviewPrep.Core.DTOs.Identity.Login;
using InterviewPrep.Core.DTOs.Identity.Register;
using InterviewPrep.Core.Entities;
using InterviewPrep.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace InterviewPrep.Infrastructure.Repositories;
public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    public AuthService(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    public async Task<LoginServiceResponseDto> Login(Login login)
    {
        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user is null)
            throw new UnauthorizedAccessException("Email or Password is incorrect!");

        if (await _userManager.IsLockedOutAsync(user))
        {
            throw new UnauthorizedAccessException("Your account is locked. Please try again after 15 min.");
        }

        var result = await _userManager.CheckPasswordAsync(user, login.Password);

        if (!result)
        {
            await _userManager.AccessFailedAsync(user);
            throw new UnauthorizedAccessException("Email or Password is incorrect!");
        }

        await _userManager.ResetAccessFailedCountAsync(user);

        var jwtSecurityToken = await _tokenService.CreateJwtTokenAsync(user);
        var userInfo = new UserInfoResult
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Id = user.Id,
            UserName = user.UserName
        };

        return new LoginServiceResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            UserInfo = userInfo
        };
    }

    public async Task<GeneralServiceResponseDto> Register(Register register)
    {
        if (await _userManager.FindByEmailAsync(register.Email) is not null)
            throw new BadRequestException("Email is already registered!");

        var user = new User
        {
            UserName = register.Email.Split('@')[0],
            Email = register.Email,
            FirstName = register.FirstName,
            LastName = register.LastName
        };

        var result = await _userManager.CreateAsync(user, register.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(",", result.Errors.Select(error => error.Description));
            throw new BadRequestException(errors);
        }

        var jwtSecurityToken = await _tokenService.CreateJwtTokenAsync(user);
        var res = await _userManager.UpdateAsync(user);

        if (res is not null)
            return new GeneralServiceResponseDto
            {
                IsSuccess = true,
                Message = "register successfully",
                StatusCode = 201
            };


        return
            new GeneralServiceResponseDto
            {
                IsSuccess = false,
                Message = "please again, user not registerd",
                StatusCode = 401
            };
    }
}