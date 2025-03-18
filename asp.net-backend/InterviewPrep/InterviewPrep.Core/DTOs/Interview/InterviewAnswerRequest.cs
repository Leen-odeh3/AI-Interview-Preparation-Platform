namespace InterviewPrep.Core.DTOs.Interview;

public class InterviewAnswerRequest
{
	public string Role { get; set; }
	public string TechStack { get; set; }
	public int YearsOfExperience { get; set; }
	public List<string> Questions { get; set; }
	public List<string> Answers { get; set; }
}
