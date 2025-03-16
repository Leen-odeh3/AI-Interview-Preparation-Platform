namespace InterviewPrep.Core.Entities;

public class Interview
{
    public int Id { get; set; }
    public string Position { get; set; }
    public int YearsOfExperience { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string TechStack { get; set; }

    public string UserId { get; set; }
    public  User User { get; set; }
}
