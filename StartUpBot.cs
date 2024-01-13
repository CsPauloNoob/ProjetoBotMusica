using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBotMusica.ComandosDeBarra;
using ProjetoBotMusica.Lavalink;

namespace ProjetoBotMusica
{
    public static class StartUpBot
    {

        public static DiscordClient _client { get; private set; }


        public static async Task ConfigurarBot(ServiceCollection services)
        {
            var client = new DiscordClient(new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                AutoReconnect = true,
                Token = Environment.GetEnvironmentVariable("MUSIC_BOT", EnvironmentVariableTarget.Machine),
                TokenType = TokenType.Bot
            }); 

            var slash = client.UseSlashCommands(new SlashCommandsConfiguration
            {
                Services = services.BuildServiceProvider()
            });

            slash.RegisterCommands<ComandosDeMusica>();

            _client = client;

            await client.ConnectAsync();
            LavalinkConfig.LavalinkInit(client);
            Console.WriteLine("ON");

            await Task.Delay(-1);
        }

    }
}