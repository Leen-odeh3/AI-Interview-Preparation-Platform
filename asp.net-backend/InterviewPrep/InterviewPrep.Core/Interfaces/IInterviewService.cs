using InterviewPrep.Core.DTOs.General;

namespace InterviewPrep.Core.Interfaces;

public interface IInterviewService
{
	Task<bool> AddInterviewAsync(InterviewRecieved interview);
	Task<UserInterviews> GetPreviousInterviewsByEmailAsync(string email);
}
