using InterviewPrep.Core.DTOs.General;

namespace InterviewPrep.Core.DTOs.Identity.Login;
public class LoginServiceResponseDto
{
    public string Token { get; set; }
    public UserInfoResult UserInfo { get; set; }
}