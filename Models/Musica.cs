using DSharpPlus.Lavalink;
using ProjetoBotMusica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBotMusica.Models
{
    internal class Musica
    {
        public ulong IdUsuario { get; set; }

        public LavalinkLoadResult Track {  get; set; }

        public EstadoDaMusica Estado {  get; set; }




    }
}
