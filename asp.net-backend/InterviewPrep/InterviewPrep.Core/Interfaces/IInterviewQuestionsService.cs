
using InterviewPrep.Core.DTOs.Interview;

namespace InterviewPrep.Core.Interfaces;

public interface IInterviewQuestionsService
{
	Task<List<string>> GenerateQuestionsAsync(InterviewRequest request);
	Task<string> AnalyzeAnswersAsync(InterviewAnswerRequest request);
}
