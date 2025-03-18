using InterviewPrep.Core.DTOs.Interview;
using InterviewPrep.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrep.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InterviewQuestionsController : ControllerBase
	{
		private readonly IInterviewQuestionsService _interviewService;

		public InterviewQuestionsController(IInterviewQuestionsService interviewService)
		{
			_interviewService = interviewService;
		}

		[HttpPost("generate-questions")]
		public async Task<IActionResult> GenerateQuestions([FromBody] InterviewRequest request)
		{
			var questions = await _interviewService.GenerateQuestionsAsync(request);
			return Ok(questions);
		}

		[HttpPost("analyze-answer")]
		public async Task<IActionResult> AnalyzeAnswer([FromBody] InterviewAnswerRequest request)
		{
			var feedback = await _interviewService.AnalyzeAnswersAsync(request);
			return Ok(new { Feedback = feedback });
		}
	}
}
