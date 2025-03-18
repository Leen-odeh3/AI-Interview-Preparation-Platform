using Microsoft.AspNetCore.Identity;

namespace InterviewPrep.Core.Entities;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Interview> Interviews { get; set; }
}
