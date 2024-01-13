using DSharpPlus.Lavalink;

namespace ProjetoBotMusica.Utils
{
    internal class FilaDeMusicas
    {
        public Dictionary<ulong, LavalinkTrack> _fila = new Dictionary<ulong, LavalinkTrack>();

        public static EstadoDaMusica EstadoGlobal;

        public FilaDeMusicas()
        { }

        public bool AdicionarMusicas(LavalinkTrack track, ulong guildId)
        {
            if (EstadoGlobal == EstadoDaMusica.Tocando)
            {
                _fila.Add(guildId, track);

                return true;
            }

            return false;
        }
    }
}