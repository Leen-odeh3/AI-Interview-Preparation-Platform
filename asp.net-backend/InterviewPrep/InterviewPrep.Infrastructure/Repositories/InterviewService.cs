using InterviewPrep.Core.Entities;
using InterviewPrep.Core.Interfaces;
using InterviewPrep.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace InterviewPrep.Core.Services;
public class InterviewService : IInterviewService
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public InterviewService(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task<string> AddInterviewToUserAsync(string userId, Interview interview)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(userId);
            return $"{userId} - User not found. serivce";
        }

        interview.UserId = userId;
        _context.Interviews.Add(interview);
        await _context.SaveChangesAsync();

        return "doneeeeee";
    }

    public async Task<User> FindByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<IEnumerable<Interview>> GetUserInterviewsAsync(string userId)
    {
        return await _context.Interviews
            .Where(i => i.UserId == userId)
            .ToListAsync();
    }
}
