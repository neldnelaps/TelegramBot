using Telegram.Bot;
using Telegram.Bot.Types;


namespace TestLoymax.Models.Сommands
{
    public class Registration : Сommand
    {
        public override string Name => "registration";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "registration!", replyToMessageId: message.MessageId);
        }
    }
}