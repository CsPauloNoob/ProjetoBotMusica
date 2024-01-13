using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.SlashCommands;
using ProjetoBotMusica.Utils;
using System.Diagnostics;

namespace ProjetoBotMusica.ComandosDeBarra
{
    internal class ComandosDeMusica : ApplicationCommandModule
    {

        public FilaDeMusicas _fila;

        EstadoDaMusica estadoMusica;

        public ComandosDeMusica(FilaDeMusicas fila)
        {
            _fila = fila;
        }


        [SlashCommand("play", "Toca uma música com base na <url> || nome da música", true)]

        public async Task play(InteractionContext ctx,
            [Option("query", "Url da música || Nome da música")] string url)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
            var userVoice = ctx.Member;
            var lavalinkInstance = ctx.Client.GetLavalink();

            if (userVoice.VoiceState != null || userVoice.VoiceState.Channel != null)
            {
                try
                {
                    var node = lavalinkInstance.ConnectedNodes.Values.First();
                    var loadResult = await node.Rest.GetTracksAsync(url);

                    if (loadResult.LoadResultType == LavalinkLoadResultType.NoMatches ||
                        loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed ||
                        !lavalinkInstance.ConnectedNodes.Any())
                    {
                        await ctx.EditResponseAsync(
                            new DiscordWebhookBuilder().
                            WithContent("Ops, algo deu errado na nossa conexão :cry:\n Tente novamente mais tarde!"));
                    }

                    else
                    {

                        await node.ConnectAsync(userVoice.VoiceState.Channel);
                        var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);

                        var track = loadResult.Tracks.FirstOrDefault();

                        if (_fila.AdicionarMusicas(track!, ctx.Guild.Id))
                        {
                            await ctx.EditResponseAsync(
                           new DiscordWebhookBuilder().
                           WithContent($"Música: {track!.Title} adicionada á fila"));
                        }

                        else
                        {
                            await conn.PlayAsync(track);
                            

                            FilaDeMusicas.EstadoGlobal = EstadoDaMusica.Tocando;

                            await ctx.EditResponseAsync(
                                new DiscordWebhookBuilder().
                                WithContent($"Tocando música: {track!.Title}"));
                        }
                    }
                }

                catch (NullReferenceException ex) { Console.WriteLine(ex); }
            }

            else
            {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder().
                    WithContent($"{ctx.User.Mention}, Por favor, se conecte a um Canal de Voz"));
            }
        }
    }
}