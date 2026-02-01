using Microsoft.AspNetCore.SignalR;
using Robo.Services;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Robo.Hubs
{
    public class IAHub : Hub
    {
        private readonly IAIService _aiService;
        private static int _onlineUsers = 0;

        public IAHub(IAIService aiService)
        {
            _aiService = aiService;
        }

        public override async Task OnConnectedAsync()
        {
            _onlineUsers++;
            await Clients.All.SendAsync("UpdateOnlineUsers", _onlineUsers);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (_onlineUsers > 0) _onlineUsers--;
            await Clients.All.SendAsync("UpdateOnlineUsers", _onlineUsers);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string userMessage)
        {
            try
            {
                var aiResponse = await _aiService.GetResponseAsync(userMessage);
                var textoLimpo = LimparTextoParaFala(aiResponse);
                await Clients.Caller.SendAsync("ReceiveMessage", textoLimpo);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", $"Erro: {ex.Message}");
            }
        }

        public async Task ResetConversation()
        {
            if (_aiService is Robo.Services.OpenAIService openAi)
                openAi.ResetConversation();
            await Clients.Caller.SendAsync("ReceiveMessage", "Nova conversa iniciada.");
        }

        private string LimparTextoParaFala(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return texto;
            texto = Regex.Replace(texto, @"([*#_`~])\1{1,}", "$1");
            texto = Regex.Replace(texto, @"(^|\s)[*#_`~]+(\s|$)", " ");
            texto = Regex.Replace(texto, @"[*_]{1,2}([^*_]+)[*_]{1,2}", "$1");
            texto = Regex.Replace(texto, @"\s{2,}", " ");
            return texto.Trim();
        }
    }
}
