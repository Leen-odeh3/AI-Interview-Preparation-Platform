using InterviewPrep.Core.DTOs.General;
using InterviewPrep.Core.DTOs.Identity.Login;
using InterviewPrep.Core.DTOs.Identity.Register;
using Microsoft.AspNetCore.Identity;

namespace InterviewPrep.Core.Interfaces;
public interface IAuthService
{
    Task<string> Login(Login user);
    Task<GeneralServiceResponseDto> Register(Register user);

}
