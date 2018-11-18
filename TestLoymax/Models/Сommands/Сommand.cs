using System;
using System.Collections.Generic;

using Telegram.Bot;
using Telegram.Bot.Types;

using TestLoymax.Entities;

namespace TestLoymax.Models.Сommands
{
    abstract class Сommand
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command) => command.Contains(Name);

        public ClientSet GetClientFromString(string surname, string firstname, string patronymic, DateTime date) => new ClientSet
        {
            Surname = surname,
            Firstname = firstname,
            Patronymic = patronymic,
            DateOfBirth = date
        };

        public bool CheckValidationOfData(List<string> text)
        {
            if (text.Count == 5)
                if (text[1] != "" && text[2] != "" && Convert.ToDateTime(text[4]) < DateTime.Now)
                    return true;
            return false;
        }
    }
}