using AutoMapper;
using InterviewPrep.Core.DTOs.Interview;
using InterviewPrep.Core.Entities;
using InterviewPrep.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InterviewPrep.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class InterviewController : ControllerBase
{
    private readonly IInterviewService _interviewService;
    public IMapper _mapper;
    public InterviewController(IInterviewService interviewService,IMapper mapper)
    {
        _interviewService = interviewService;
        _mapper = mapper;
    }

    [HttpPost("interviews")]
    public async Task<IActionResult> AddInterview([FromBody] InterviewDTO interviewDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            return Unauthorized("User is not authenticated.");
        }

        var user = await _interviewService.FindByIdAsync(userId);
        if (user == null)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(userId);
            return NotFound($"{userId} - User not found.");
        }

        var interview = _mapper.Map<Interview>(interviewDto);

        var result = await _interviewService.AddInterviewToUserAsync(userId, interview);
        if (result.Contains("User not found"))
        {
            return NotFound(result);
        }

        return Ok($"{interview.Position} interview added successfully for user {userId}");
    }



    /*
     * 
      {
  "email": "string12@gmail.com",
  "password": "string12@gmail.comS"
}
    */

    [HttpGet("interviews")]
    public async Task<IActionResult> GetInterviews()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User is not authenticated.");
        }

        var interviews = await _interviewService.GetUserInterviewsAsync(userId);
        return Ok(interviews);
    }
}
