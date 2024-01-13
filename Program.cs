using Microsoft.Extensions.DependencyInjection;
using ProjetoBotMusica;
using ProjetoBotMusica.Utils;


var services = new ServiceCollection();

services.AddSingleton(typeof(FilaDeMusicas));
await StartUpBot.ConfigurarBot(services);