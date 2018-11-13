using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Telegram.Bot;

using TestLoymax.Models.Сommands;

namespace TestLoymax.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        public static List<Сommand> commandsList;
       public static IReadOnlyList<Сommand> Commands { get => commandsList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Сommand>();
            commandsList.Add(new Registration());

            client = new TelegramBotClient(Settings.Key);
            var hook = string.Format(Settings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}