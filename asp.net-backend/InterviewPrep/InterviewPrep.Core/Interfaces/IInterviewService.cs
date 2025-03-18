using InterviewPrep.Core.DTOs.Interview;
using InterviewPrep.Core.Entities;

namespace InterviewPrep.Core.Interfaces;
public interface IInterviewService
{
    Task<IEnumerable<Interview>> GetUserInterviewsAsync(string userId);
    Task<string> AddInterviewToUserAsync(string userId, Interview interview);
    Task<User> FindByIdAsync(string userId);
}