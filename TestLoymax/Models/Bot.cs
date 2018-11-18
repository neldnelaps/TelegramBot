using System.Collections.Generic;
using System.Threading.Tasks;

using Telegram.Bot;

using TestLoymax.Entities;
using TestLoymax.Models.Сommands;

namespace TestLoymax.Models
{
    static class Bot
    {
        private static TelegramBotClient client;

        private static List<Сommand> commandsList { get; set; }

        public static IReadOnlyList<Сommand> Commands { get => commandsList.AsReadOnly(); }

        public static UsersDBEntities usersDB;

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (client != null)
                return client;

            commandsList = new List<Сommand>
            {
                new Registration(),
                new Start(),
                new Delete(),
                new Select()
            };

            usersDB = new UsersDBEntities();
            // WebProxy wp = new WebProxy("", true);
            // wp.Credentials = new NetworkCredential("user1", "user1Password");

            client = new TelegramBotClient(Settings.ApiToken);

            var hook = string.Format(Settings.Url, "update");

            await client.SetWebhookAsync(hook);
           
            return client;
        }
    }
}