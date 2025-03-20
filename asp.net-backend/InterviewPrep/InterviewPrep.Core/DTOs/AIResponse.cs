
using System.Text.Json.Serialization;

namespace InterviewPrep.Core.DTOs;

public class AIResponse
{
	[JsonPropertyName("choices")]
	public List<Choice>? Choices { get; set; }
}

public class Choice
{
	[JsonPropertyName("message")]
	public AIMessage? Message { get; set; }
}

public class AIMessage
{
	[JsonPropertyName("role")]
	public string? Role { get; set; }

	[JsonPropertyName("content")]
	public string? Content { get; set; }

}
