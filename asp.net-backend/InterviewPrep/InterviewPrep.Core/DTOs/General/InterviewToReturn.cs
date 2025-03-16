namespace InterviewPrep.Core.DTOs.General;

public class InterviewToReturn
{
	public string Position { get; set; }
	public int YearsOfExperience { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public string TechStack { get; set; }
}
