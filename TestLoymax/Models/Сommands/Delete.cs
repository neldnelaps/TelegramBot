using System;
using System.Linq;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestLoymax.Models.Сommands
{
    class Delete : Сommand
    {
        public override string Name => "/delete";

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
                                                                              u.DateOfBirth==userText.DateOfBirth);
                    if (userFind != null)
                    {
                        Bot.usersDB.ClientSets.Remove(userFind);
                        Bot.usersDB.SaveChanges();
                        client.SendTextMessageAsync(message.Chat.Id, "The client has been deleted!");
                    }
                    else
                        client.SendTextMessageAsync(message.Chat.Id, "There is no such client in the database");
                }
                else
                    client.SendTextMessageAsync(message.Chat.Id, " Data entered incorrectly! Delete.(Example: /delete@Surname@Firstname@Patronymic@mm.dd.yyyy).");
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
