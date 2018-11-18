using System;
using System.Collections.Generic;
using System.Linq;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestLoymax.Models.Сommands
{
    class Select : Сommand
    {
        public override string Name => "/select";

        public override void Execute(Message message, TelegramBotClient client)
        {
            try
            {
                var text = message.Text.Split('@').Select(x => x.Trim()).ToList();
                if (CheckValidationOfData(text))
                {
                    var userText = GetClientFromString(text[1], text[2], text[3], Convert.ToDateTime(text[4]));
                    var userFind = Bot.usersDB.ClientSets.FirstOrDefault(u => u.Surname.ToLower() == userText.Surname.ToLower() &&
                                                                              u.Firstname.ToLower() == userText.Firstname.ToLower() &&
                                                                              u.Patronymic.ToLower() == userText.Patronymic.ToLower() &&
                                                                              u.DateOfBirth == userText.DateOfBirth);
                    var answer = (userFind != null) ? $"Client: Id - {userFind.Id} {userFind.Surname} {userFind.Firstname} {userFind.Patronymic} {String.Format("{0:d}", userFind.DateOfBirth)}"
                                                    : "There is no such client in the database";
                    client.SendTextMessageAsync(message.Chat.Id, answer, replyToMessageId: message.MessageId);
                }
                else
                    client.SendTextMessageAsync(message.Chat.Id, " Data entered incorrectly! Get Information.(Example: /select@Surname@Firstname@Patronymic@mm.dd.yyyy).");
            }
            catch (FormatException ex)
            {
                client.SendTextMessageAsync(message.Chat.Id, ex.Message);
            }
            catch (Exception ex)
            {
                client.SendTextMessageAsync(message.Chat.Id, ex.Message);
            }
        }
    }
}