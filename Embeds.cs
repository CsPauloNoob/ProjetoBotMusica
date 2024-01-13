using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace Templates {

    // Construtor de embeds 
    public static class Embeds {

        /*
         * Tem
         */
        public static void Template (MessageCreateEventArgs e) {

            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
            builder.Color = new DiscordColor(169, 216, 255);
            builder.AddField("name", "content: true", true);
            builder.AddField("name", "content: false", false);
            builder.ImageUrl = e.Message.Author.AvatarUrl;
            //builder.ThumbnailUrl = e.Message.Author.AvatarUrl;
            builder.Title = "Titulo";
            builder.Url = e.Message.Author.AvatarUrl;
            builder.Description = "Descrição";
            builder.Author = new DiscordEmbedBuilder.EmbedAuthor();
            builder.Author.IconUrl = e.Message.Author.AvatarUrl;
            builder.Author.Name = e.Message.Author.Username;
            builder.Author.Url = e.Message.Author.AvatarUrl;
            builder.Footer = new DiscordEmbedBuilder.EmbedFooter();
            builder.Footer.IconUrl = e.Message.Author.AvatarUrl;
            builder.Footer.Text = "footer";

            //e.Message.RespondAsync("", false, builder.Build());
        }
    }
}