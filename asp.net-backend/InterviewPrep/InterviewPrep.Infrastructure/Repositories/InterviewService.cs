using InterviewPrep.Core.DTOs.General;
using InterviewPrep.Core.Entities;
using InterviewPrep.Core.Interfaces;
using InterviewPrep.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;

namespace InterviewPrep.Infrastructure.Repositories;

public class InterviewService : IInterviewService
{
	private readonly AppDbContext _dbContext;
	private readonly UserManager<User> _userManager;

	public InterviewService(AppDbContext dbContext , UserManager<User> userManager)
    {
		_dbContext = dbContext;
		_userManager=userManager;
	}
    public async Task<bool> AddInterviewAsync(InterviewRecieved interviewRecieved)
	{
		var user = await _userManager.FindByEmailAsync(interviewRecieved.UserEmail);
		if(user is null) return false;

		var interview = new Interview()
		{
			Position = interviewRecieved.Position,
			YearsOfExperience = interviewRecieved.YearsOfExperience,
			TechStack = interviewRecieved.TechStack,
			UserId = user.Id,
		};

		_dbContext.Interviews.Add(interview);

		return _dbContext.SaveChanges() > 0;
	}

	public async Task<UserInterviews> GetPreviousInterviewsByEmailAsync(string email)
	{
		var user = await _userManager.FindByEmailAsync(email);
		if (user is null) return null;

		var interviews = _dbContext.Interviews.Where(I => I.UserId == user.Id).ToList();
		
		var userInterviews = new UserInterviews() { UserEmail = user.Email, Interviews = new List<InterviewToReturn>() };

		if (interviews is null || interviews.Count == 0)
			return userInterviews;


        foreach (var interview in interviews)
        {
			userInterviews.Interviews.Add(new InterviewToReturn()
			{
				Position = interview.Position,
				YearsOfExperience = interview.YearsOfExperience,
				TechStack = interview.TechStack,
				CreatedAt = interview.CreatedAt,
			});

		}
        return userInterviews;
	}
}
