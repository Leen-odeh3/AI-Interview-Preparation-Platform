using InterviewPrep.Core.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using InterviewPrep.Core.DTOs.Interview;
using InterviewPrep.Core.DTOs;

namespace InterviewPrep.Infrastructure.Repositories;

public class InterviewQuestionsService : IInterviewQuestionsService
{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey = "08c967bd08394e42977fac9ad7da9ea4";
		private readonly string _apiUrl = "https://api.aimlapi.com/v1/chat/completions";

		public InterviewQuestionsService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
		}

		public async Task<List<string>> GenerateQuestionsAsync(InterviewRequest request)
		{
			var aiRequest = new
			{
				model = "mistralai/Mistral-7B-Instruct-v0.2",
				messages = new[]
				{
					new { role = "system", content = "You are an AI interviewer. Generate interview questions." },
					new { role = "user", content = $"Generate interview questions for a {request.YearsOfExperience}-year {request.Role} skilled in {request.TechStack}. Only return a list of questions." }
				},
				temperature = 0.7,
				max_tokens = 256
			};

			var content = new StringContent(JsonSerializer.Serialize(aiRequest), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync(_apiUrl, content);

			if (!response.IsSuccessStatusCode) return new List<string> { "Failed to generate questions." };

			var responseContent = await response.Content.ReadAsStringAsync();
			var aiResponse = JsonSerializer.Deserialize<AIResponse>(responseContent);

			return aiResponse?.Choices?[0]?.Message?.Content?.Split('\n').ToList() ?? new List<string>();
		}

	public async Task<string> AnalyzeAnswersAsync(InterviewAnswerRequest request)
	{
		var questionsAndAnswers = string.Join("\n", request.Questions.Zip(request.Answers, (q, a) => $"Q: {q}\nA: {a}"));

		var aiRequest = new
		{
			model = "mistralai/Mistral-7B-Instruct-v0.2",
			messages = new[]
			{
			new { role = "system", content = "You are an AI interviewer. Analyze the following interview responses and provide detailed feedback." },
			new { role = "user", content = $"Analyze the responses for a {request.YearsOfExperience}-year {request.Role} skilled in {request.TechStack}.\n\n{questionsAndAnswers}" }
		},
			temperature = 0.7,
			max_tokens = 512
		};

		var content = new StringContent(JsonSerializer.Serialize(aiRequest), Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync(_apiUrl, content);

		if (!response.IsSuccessStatusCode) return "Failed to analyze answers.";

		var responseContent = await response.Content.ReadAsStringAsync();
		var aiResponse = JsonSerializer.Deserialize<AIResponse>(responseContent);

		return aiResponse?.Choices?[0]?.Message?.Content ?? "No feedback generated.";
	}

}
