using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestLoymax.Models.Сommands
{
    public abstract class Сommand
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command) => command.Contains(this.Name) && command.Contains(Settings.Name);
      
    }
}