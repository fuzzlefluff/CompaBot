using System;
using DSharpPlus;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace Compa
{
    class Program
    {

        static DiscordClient discord;
        static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult(); 
        }

        static async Task MainAsync(string[] args)
        {
            //Create the Discord connection
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "MzYwMjI4MTQwMDQ1MzAzODIw.DKShkA.3dmj3m04zL8HiSSPxSArmKC9px8",
                TokenType = TokenType.Bot,
                UseInternalLogHandler =true,
                LogLevel = LogLevel.Debug
            });
            
            //Check status of Compa
            discord.MessageCreated += async e =>
             {
                 if (e.Message.Content.ToLower().StartsWith("ping"))
                     await e.Message.RespondAsync("pong!");
             };


            //Create the Commands
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "-"
            });

            commands.RegisterCommands<CompaCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}
