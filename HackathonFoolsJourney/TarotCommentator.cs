using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HackathonFoolsJourney
{
    public class TarotCommentator
    {
        private readonly HttpClient _http = new HttpClient();
        string apiKey = null;     // ← This is the secret
        //replace with real key when ready 

        private readonly string[] _fallbacks = {
            "The cards weep for what you've done here.",
            "A bold strategy. Boldly wrong.",
            "The Fool himself could not have done worse.",
            "Remarkable. You have achieved nothing.",
            "Even reversed cards did not deserve this.",
        };

        public async Task<string> GetRoastAsync(bool isWin, int score, string worstMove)
        {
            var apiTask = CallOpenAIAsync(isWin, score, worstMove);
            var timeoutTask = Task.Delay(2500);

            if (await Task.WhenAny(apiTask, timeoutTask) == timeoutTask)
                return _fallbacks[new Random().Next(_fallbacks.Length)];

            return await apiTask;
        }

        private async Task<string> CallOpenAIAsync(bool isWin, int score, string worstMove)
        {
            string userPrompt = isWin
                ? $"The player just WON. Score: {score}. Roast them so they don't get confident."
                : $"The player just LOST. Score: {score}. Worst move: {worstMove}. Destroy them.";

            var requestBody = new
            {
                model = "gpt-4o-mini",
                max_tokens = 120,
                messages = new[]
                {
                    new { role = "system", content = "You are The Fool, a sarcastic mystical tarot character. Deliver sharp witty trash talk under 2 sentences. No profanity. Reference tarot lore." },
                    new { role = "user", content = userPrompt }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.SendAsync(request);
            var responseJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API RESPONSE: " + responseJson);
            using var doc = JsonDocument.Parse(responseJson);
            return doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? _fallbacks[0];
        }
    }
}