using OpenAI.Chat;
using OpenAI;

namespace Robo.Services
{
    public class OpenAIService : IAIService
    {
        private readonly OpenAIClient _client;
        private readonly List<ChatMessage> _conversationHistory;
        private readonly string _model;

        public OpenAIService(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            _model = configuration["OpenAI:Model"] ?? "gpt-4o-mini";

            _client = new OpenAIClient(apiKey);
            _conversationHistory = new List<ChatMessage>
            {
                new SystemChatMessage("Você é um assistente de IA. Responda em português brasileiro de forma clara e concisa.")
            };
        }

        public async Task<string> GetResponseAsync(string userMessage)
        {
            try
            {
                _conversationHistory.Add(new UserChatMessage(userMessage));

                var chatClient = _client.GetChatClient(_model);

                var completion = await chatClient.CompleteChatAsync(_conversationHistory);

                var response = completion.Value.Content[0].Text;

                _conversationHistory.Add(new AssistantChatMessage(response));

             
                if (_conversationHistory.Count > 21) 
                {
                    _conversationHistory.RemoveRange(1, 2);
                }

                return response;
            }
            catch (Exception ex)
            {
                return $"Erro ao processar sua solicitação: {ex.Message}";
            }
        }

        public void ResetConversation()
        {
            if (_conversationHistory.Count > 1)
                _conversationHistory.RemoveRange(1, _conversationHistory.Count - 1);
        }
    }
}
