using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Compa //Matt's Branch
{
    public class CompaCommands
    {
        Random rnd;
        string[] jojourls =
        {
            "https://media.giphy.com/media/aYVhZCKdtXZSw/giphy.gif",
            "https://media0.giphy.com/media/h9rBcBywX895S/giphy.gif",
            "https://media.giphy.com/media/odFXRT6XfDaes/giphy.gif",
            "https://media.giphy.com/media/ibrbldwMU1GyA/giphy.gif",
            "https://media.giphy.com/media/iP8P6sbQTrmMM/giphy.gif",
            "https://media.giphy.com/media/Vo4zWc1JcjxIc/giphy.gif",
            "http://i0.kym-cdn.com/photos/images/newsfeed/000/089/820/128925608331.gif",
            "http://i0.kym-cdn.com/photos/images/newsfeed/000/750/603/df8.jpg",
            "http://i0.kym-cdn.com/photos/images/newsfeed/000/425/276/152.jpg",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1452954334-80cf4a4240a2a6c3377d17c619a3e524.png",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1453142043-73ace8ea55c566e11f1c1e0dabdef540.png",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1452955561-840d30df0f5c1adfd2e8cdb5bd49463e.jpeg",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1453144351-65be9cef5c79b1a7402b7ffce44fad96.jpeg",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1453145579-871dd5ffa8977e6d36ca2c8bc6e5d4c5.png",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1452956435-292ff0d1866dd11d12dccba3c20b0a9a.png",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1452963891-44358e833c27c9facc7e2abd870c0384.jpeg",
            "https://myanimelist.cdn-dena.com/s/common/uploaded_files/1452965721-ee120a3e09c90b47175f67b0d4dae7a6.jpeg",
            "https://i.imgur.com/e3UJ5DB.jpg",
            "https://i.imgur.com/ZTHI3X3.jpg"
        };
        string[] lewdurls =
         {
            ""
         };
        string[] facepalurls =
         {
            "https://media.giphy.com/media/XsUtdIeJ0MWMo/giphy.gif",
            "http://www.reactiongifs.com/r/facepalm.gif"
         };

        List<string> decisionOptions = new List<string>();


        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }

        [Command("fuzzlefluff"), Aliases("matt", "fuzzle", "10/10waifu", "crystalco")]
        public async Task Fuzzlefluff(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Did you mean MURDERER?!");
        }
        //Commands Summarizing People
        [Command("adam"), Aliases("crash", "blackmesa", "crashdmmy27")]
        public async Task Adam(CommandContext ctx)
        {
            string[] names = { "Princess", "Master", "CFO of Crystal Mesa", "The One in Charge", "The Princes in Charge", "Hentai Lover" };
            rnd = new Random();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Did you mean {names[rnd.Next(names.Length)]}?");
        }
        [Command("trey"), Aliases("skyking", "laughingbear", "zinzukoo", "blackman")]
        public async Task Trey(CommandContext ctx)
        {
            string[] names = { "Token Black Guy", "Dedicated Pocket Lucio", "Underpaid 3D Artist", "the only person qualified to talk about race", "Snobby Bookworm" };
            rnd = new Random();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Did you mean {names[rnd.Next(names.Length)]}?");
        }
        [Command("andy"), Aliases("collector", "thecollector", "starwarsguy")]
        public async Task Andy(CommandContext ctx)
        {
            string[] names = { "the greatest threat to Mankind", "a terrifying man with bottles", "the guy who needs to get over starwars", "The one who is never online", "Thank" };
            rnd = new Random();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Did you mean {names[rnd.Next(names.Length)]}?");
        }
        [Command("lawton"), Aliases("rgbman", "amdman")]
        public async Task Lawton(CommandContext ctx)
        {
            string[] names = { "the one who still hasn't beat zelda", "the only person who's bought amd" };
            rnd = new Random();
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Did you mean {names[rnd.Next(names.Length)]}?");
        }
        //Compa Decision Commands
        [Command("add")]
        public async Task Add(CommandContext ctx, params string[] args)
        {
            string input = "";
            for (int i = 0; i < args.Length; i++)
            {
                input += args[i] + " ";
            }
            decisionOptions.Add(input);
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Compa added {input} to the list!");
        }

        [Command("decide")]
        public async Task Decide(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            rnd = new Random();
            await ctx.RespondAsync($"Compa thinks you should {decisionOptions[rnd.Next(decisionOptions.Count)]}!");
            decisionOptions.Clear();
        }

        [Command("decidenow"), Description("Compa will decide what you should do. Just give her a list")]
        public async Task DecideNow(CommandContext ctx, [Description("The items to pick from")] params string[] args)
        {
            string fullInput = "";
            for (int i = 0; i < args.Length; i++)
            {
                fullInput += args[i] + " ";
            }

            string[] options = fullInput.Split(',');


            await ctx.TriggerTypingAsync();
            rnd = new Random();
            await ctx.RespondAsync($"Compa thinks you should {options[rnd.Next(options.Length)]}!");

        }
        //Meme Repositoires
        [Command("jojo")]
        public async Task JoJo(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            rnd = new Random();
            var embed = new DiscordEmbedBuilder
            {
                ImageUrl = jojourls[rnd.Next(jojourls.Length)]
            };

            await ctx.RespondAsync("", embed: embed);
        }
        [Command("lewd")]
        public async Task Lewd(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            rnd = new Random();
            var embed = new DiscordEmbedBuilder
            {
                ImageUrl = lewdurls[rnd.Next(lewdurls.Length)]
            };

            await ctx.RespondAsync("", embed: embed);
        }
        [Command("picard"), Aliases("facepalm")]
        public async Task picard(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            rnd = new Random();
            var embed = new DiscordEmbedBuilder
            {
                ImageUrl = facepalurls[rnd.Next(lewdurls.Length)]
            };

            await ctx.RespondAsync("", embed: embed);
        }
        //Waifu Rating
        [Command("ratewaifu"), Aliases("rate")]
        public async Task ratewaifu(CommandContext ctx, params string[] args)
        {
            string fullInputSpaces = "";
            string fullInput = "";
            Int32 ratingValue = 0;
            //get two strings, one with spaces and one without
            for (int i = 0; i < args.Length; i++)
            {
                fullInputSpaces += args[i] + " ";
                fullInput += args[i];
            }
            //Uppercase spaceless string
            fullInput = fullInput.ToUpper();
            if (fullInput == "MATTHEWPRINDLE" || fullInput == "MATTPRINDLE" || fullInput == "FUZZLEFLUFF" || fullInput == "FUZZLE")
            {
                await ctx.TriggerTypingAsync();
                await ctx.RespondAsync($"I think " + fullInputSpaces + " is a 11/10 waifu");
            }

            else if (fullInput == "ADAM" || fullInput == "CRSHDMMY27" || fullInput == "CRASH" || fullInput == "BLACKMESA" || fullInput == "ADAMWALTON")
            {
                await ctx.TriggerTypingAsync();
                await ctx.RespondAsync($"How many times do I have to tell you that you're a creep!");
            }
            else if (fullInput == "TREY" || fullInput == "SKYKING" || fullInput == "THESKYKING" || fullInput == "LAUGHINGBEAR" || fullInput == "ZINZUKOO")
            {
                await ctx.TriggerTypingAsync();
                await ctx.RespondAsync($"I think " + fullInputSpaces + " is a Sexy Motherfucker/10 waifu");
            }
            else if (fullInput == "ANDY" || fullInput == "COLLECTOR" || fullInput == "THECOLLECTOR")
            {
                await ctx.TriggerTypingAsync();
                await ctx.RespondAsync($"I think The Collector is a MUCH SCARE/10");
            }
            else
            {
                char judgechar = 'a';
                for (int i = 0; i < fullInput.Length; i++)
                {
                    judgechar = fullInput[i];
                    if (judgechar == 'A') { ratingValue += 472341; }
                    if (judgechar == 'B') { ratingValue += 8757; }
                    if (judgechar == 'C') { ratingValue += 16423; }
                    if (judgechar == 'D') { ratingValue -= 462; }
                    if (judgechar == 'E') { ratingValue += 1; }
                    if (judgechar == 'F') { ratingValue -= 9543125; }
                    if (judgechar == 'G') { ratingValue -= 1; }
                    if (judgechar == 'H') { ratingValue += 742451; }
                    if (judgechar == 'I') { ratingValue += 2; }
                    if (judgechar == 'J') { ratingValue += 111; }
                    if (judgechar == 'K') { ratingValue -= 3; }
                    if (judgechar == 'L') { ratingValue += 1; }
                    if (judgechar == 'M') { ratingValue -= 4; }
                    if (judgechar == 'N') { ratingValue += 6; }
                    if (judgechar == 'O') { ratingValue += 1; }
                    if (judgechar == 'P') { ratingValue += 2; }
                    if (judgechar == 'Q') { ratingValue -= 1; }
                    if (judgechar == 'R') { ratingValue += 13413; }
                    if (judgechar == 'S') { ratingValue += 713243; }
                    if (judgechar == 'T') { ratingValue += 11324; }
                    if (judgechar == 'U') { ratingValue += 1; }
                    if (judgechar == 'V') { ratingValue -= 6; }
                    if (judgechar == 'W') { ratingValue += 1; }
                    if (judgechar == 'X') { ratingValue += 2; }
                    if (judgechar == 'Y') { ratingValue -= 1; }
                    if (judgechar == 'Z') { ratingValue += 5123413; }
                }
                Random raiting = new Random(ratingValue);
                int temp = raiting.Next(0, 110);
                if (temp < 5) { temp = 0; }
                if (temp > 5 && temp < 10) { temp = 1; }
                if (temp > 10 && temp < 20) { temp = 2; }
                if (temp > 20 && temp < 30) { temp = 3; }
                if (temp > 30 && temp < 40) { temp = 4; }
                if (temp > 40 && temp < 50) { temp = 5; }
                if (temp > 50 && temp < 60) { temp = 6; }
                if (temp > 60 && temp < 70) { temp = 7; }
                if (temp > 70 && temp < 80) { temp = 8; }
                if (temp > 80 && temp < 90) { temp = 9; }
                if (temp > 90 && temp < 100) { temp = 10; }
                if (temp > 100) { temp = 11; }
                await ctx.TriggerTypingAsync();
                await ctx.RespondAsync($"I think " + fullInputSpaces + " is a " + temp + "/10 waifu");
            }
        }
        //say things in big text
        [Command("bigtext")]
        public async Task bigText(CommandContext ctx, params string[] args)
        {
            string fullInputSpaces = "";
            string formatedString = "";
            Int32 ratingValue = 0;
            //get two strings, one with spaces and one without
            for (int i = 0; i < args.Length; i++)
            {
                fullInputSpaces += args[i] + " ";

            }
            fullInputSpaces = fullInputSpaces.ToUpper();
            for (int i = 0; i < fullInputSpaces.Length; i++)
            {
                if (fullInputSpaces[i] == ' ') { formatedString += "   "; }
                else if (fullInputSpaces[i] == 'A') { formatedString += ":regional_indicator_a:"; }
                else if (fullInputSpaces[i] == 'B') { formatedString += ":regional_indicator_b:"; }
                else if (fullInputSpaces[i] == 'C') { formatedString += ":regional_indicator_c:"; }
                else if (fullInputSpaces[i] == 'D') { formatedString += ":regional_indicator_d:"; }
                else if (fullInputSpaces[i] == 'E') { formatedString += ":regional_indicator_e:"; }
                else if (fullInputSpaces[i] == 'F') { formatedString += ":regional_indicator_f:"; }
                else if (fullInputSpaces[i] == 'G') { formatedString += ":regional_indicator_g:"; }
                else if (fullInputSpaces[i] == 'H') { formatedString += ":regional_indicator_h:"; }
                else if (fullInputSpaces[i] == 'I') { formatedString += ":regional_indicator_i:"; }
                else if (fullInputSpaces[i] == 'J') { formatedString += ":regional_indicator_j:"; }
                else if (fullInputSpaces[i] == 'K') { formatedString += ":regional_indicator_k:"; }
                else if (fullInputSpaces[i] == 'L') { formatedString += ":regional_indicator_l:"; }
                else if (fullInputSpaces[i] == 'M') { formatedString += ":regional_indicator_m:"; }
                else if (fullInputSpaces[i] == 'N') { formatedString += ":regional_indicator_n:"; }
                else if (fullInputSpaces[i] == 'O') { formatedString += ":regional_indicator_o:"; }
                else if (fullInputSpaces[i] == 'P') { formatedString += ":regional_indicator_p:"; }
                else if (fullInputSpaces[i] == 'Q') { formatedString += ":regional_indicator_q:"; }
                else if (fullInputSpaces[i] == 'R') { formatedString += ":regional_indicator_r:"; }
                else if (fullInputSpaces[i] == 'S') { formatedString += ":regional_indicator_s:"; }
                else if (fullInputSpaces[i] == 'T') { formatedString += ":regional_indicator_t:"; }
                else if (fullInputSpaces[i] == 'U') { formatedString += ":regional_indicator_u:"; }
                else if (fullInputSpaces[i] == 'V') { formatedString += ":regional_indicator_v:"; }
                else if (fullInputSpaces[i] == 'W') { formatedString += ":regional_indicator_w:"; }
                else if (fullInputSpaces[i] == 'X') { formatedString += ":regional_indicator_x:"; }
                else if (fullInputSpaces[i] == 'Y') { formatedString += ":regional_indicator_y:"; }
                else if (fullInputSpaces[i] == 'Z') { formatedString += ":regional_indicator_z:"; }
                else if (fullInputSpaces[i] == '0') { formatedString += ":zero:"; }
                else if (fullInputSpaces[i] == '1') { formatedString += ":one:"; }
                else if (fullInputSpaces[i] == '2') { formatedString += ":two:"; }
                else if (fullInputSpaces[i] == '3') { formatedString += ":three:"; }
                else if (fullInputSpaces[i] == '4') { formatedString += ":four:"; }
                else if (fullInputSpaces[i] == '5') { formatedString += ":five:"; }
                else if (fullInputSpaces[i] == '6') { formatedString += ":six:"; }
                else if (fullInputSpaces[i] == '7') { formatedString += ":seven:"; }
                else if (fullInputSpaces[i] == '8') { formatedString += ":eight:"; }
                else if (fullInputSpaces[i] == '9') { formatedString += ":nine:"; }
                else { formatedString += ":question:"; }
            }
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"" + formatedString);
        }
        //Deletes all user commands and Compa Responses
        [Command("clean")]
        public async Task clean(CommandContext ctx)
        {
            List<DiscordMessage> deleteQue = new List<DiscordMessage>(100);
            IReadOnlyList<DiscordMessage> chatLog = new DiscordMessage[100];
            chatLog = await ctx.Channel.GetMessagesAsync(100);
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"I just pulled 100 messages!");
            await ctx.RespondAsync($""+chatLog[1].Content);
            for (int i = 0; i < chatLog.Count; i++)
            {
                DiscordMessage checkMessage = chatLog[i];
                if(checkMessage.Content[0] == '~'|| checkMessage.Content[0]=='-'|| checkMessage.Author.IsBot)
                {deleteQue[i] = chatLog[i];}
            }
            await ctx.Channel.DeleteMessagesAsync(deleteQue);
            await ctx.RespondAsync($"I just deleted some stuff!");
        }
        //Danbooru Search
        [Command("hentai")]
        public async Task hentai(CommandContext ctx, String input)
        {
            if (input.ToLower() == "compa")
                await ctx.RespondAsync("Why are you looking for porn of me?");
            var danbooruLink = "https://danbooru.donmai.us/posts.xml?tags=" + input + "&random=true&limit=1";
            var client = new HttpClient();
            var data = await client.GetStringAsync(danbooruLink);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNodeList node = doc.GetElementsByTagName("file-url");


            await ctx.TriggerTypingAsync();
            var embed = new DiscordEmbedBuilder
            {
                Title = "",
                ImageUrl = "https://danbooru.donmai.us" + node[0].InnerText
            };
            await ctx.RespondAsync("", embed: embed);
        }

        [Command("nowa")]
        public async Task tsunday(CommandContext ctx)
        {
            var danbooruLink = "https://danbooru.donmai.us/posts.xml?tags=noire&random=true&limit=1";
            var client = new HttpClient();
            var data = await client.GetStringAsync(danbooruLink);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNodeList node = doc.GetElementsByTagName("file-url");


            await ctx.TriggerTypingAsync();
            var embed = new DiscordEmbedBuilder
            {
                Title = "",
                ImageUrl = "https://danbooru.donmai.us" + node[0].InnerText
            };
            await ctx.RespondAsync("", embed: embed);
        }
    }
}
