using System;
using DSharpPlus;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using System.Threading;
using DSharpPlus.Entities;

namespace Compa
{
    class Program
    {

        static DiscordClient discord;
        static CommandsNextModule commands;
        static Timer GameGuard;

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
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            discord.Ready += Discord_Ready;

            //Check status of Compa
            discord.MessageCreated += async e =>
             {
                 if (e.Message.Content.ToLower().StartsWith("ping"))
                     await e.Message.RespondAsync("pong!");
             };

            // Check status of Compa
              discord.MessageCreated += async e =>
               {
                  if (e.Message.Content.ToLower().StartsWith("-exit"))
                   {
                       await e.Message.RespondAsync($"👋 Bye Bye");
                       await discord.DisconnectAsync();
                       Environment.Exit(-1);
                   }

              };


            //Create the Commands
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "-"
            });

            commands.RegisterCommands<CompaCommands>();




            await discord.ConnectAsync();
            // await Task.Delay(-1);

            //discord.UpdateStatusAsync(new DSharpPlus.Entities.Game("Healing Neptune")).GetAwaiter().GetResult();
            await Task.Delay(-1);
        }

        private static Task Discord_Ready(DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            GameGuard = new Timer(TimerCallback, null, TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(15));
            return Task.Delay(0);

        }
        private static void TimerCallback(object _)
        {
            try
            {
                discord.UpdateStatusAsync(new Game("Healing Neptune")).GetAwaiter().GetResult();
            }
            catch (Exception) { }
        }
    }
}
