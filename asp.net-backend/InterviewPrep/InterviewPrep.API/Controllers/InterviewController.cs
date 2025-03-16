using InterviewPrep.Core.DTOs.General;
using InterviewPrep.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrep.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewController : ControllerBase
{
	private readonly IInterviewService _interviewService;

	public InterviewController(IInterviewService interviewService)
    {
		_interviewService=interviewService;
	}


    [HttpPost("addinterview")]
	public async Task<ActionResult<InterviewRecieved>> AddInterview(InterviewRecieved interviewRecieved)
	{
		var added = await _interviewService.AddInterviewAsync(interviewRecieved);
		
		if (!added) return BadRequest("This user doesn't exist in the system");

		return Ok(interviewRecieved);
	}


	[HttpGet("getpreviousinterviews")]
	public async Task<ActionResult<UserInterviews>> GetUserPreviousInterviews(string email)
	{
		var result = await _interviewService.GetPreviousInterviewsByEmailAsync(email);

		if (result is null) return NotFound("This user doesn't exist in the system");

		return Ok(result);
    }

}
