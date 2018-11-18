using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestLoymax.Models.Сommands
{
    class Start : Сommand
    {
        public override string Name => "/start";

        public override void Execute(Message message, TelegramBotClient client) =>
            client.SendTextMessageAsync(message.Chat.Id,
                $"Command list: {Name} - launch bot; " +
                "/registration - client registration; " +
                "/delete - client delete; " +
                "/select - getting client information.");
    }
}