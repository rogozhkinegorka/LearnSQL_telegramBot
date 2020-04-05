using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using MihaZupan;
using ApiAiSDK;
using ApiAiSDK.Model;
using static SQL_teleBOT.ConnectionWithDB;

namespace SQL_teleBOT
{
    class Program
    {
        private static TelegramBotClient Bot;
        static ApiAi apiAi;
        static void Main(string[] args)
        {
            ConnectionWithDB.CreateDB();
            //Console.WriteLine(ConnectionWithDB.getMessages());
            var proxy = new HttpToSocks5Proxy("96.96.33.133", 1080);
            Bot = new TelegramBotClient("748399359:AAGp6fLaxWWTPGwTXhHQrCiHQS_VXTMEuwM", proxy);
            AIConfiguration config = new AIConfiguration("69dac9ca91bd47e6b70c193e2748d8cb", SupportedLanguage.Russian);
            apiAi = new ApiAi(config);
            var me = Bot.GetMeAsync().Result;
            Console.WriteLine(me.FirstName);
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnCallbackQuery += Bot_OnCallbackQuery;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();

        }

        private static async void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            string textButton = e.CallbackQuery.Data;
            string name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";
            Console.WriteLine($"{name} нажал кнопку {textButton}!");
            await Bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"Вы нажали кнопку {textButton}!");
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.Text) return;
            Console.WriteLine($"{message.From.FirstName} {message.From.LastName} написал: '{message.Text}'");
            ConnectionWithDB.Input($"{message.From.FirstName} {message.From.LastName}", message.Text);
            switch (message.Text)
            {
                case "/start":
                    string text =
@"Привет! Я бот, помогающий новичкам выучить синтаксис языка SQL!
Вот, что я умею:

-В меня вшит небольшой справочник — напиши мне название любого оператора, а я выдам тебе про него информацию

-помимо получения справки со мной можно просто пообщаться, например, напиши ""Привет""

-кроме того я сохраняю все сообщения от всех пользователей, ты можешь их просмотреть, если введешь секретное слово

У меня есть несколько команд:
/start — запуск бота
/keyboard — показать клавиатуру-меню";
                    await Bot.SendTextMessageAsync(message.From.Id, text);
                    break;
                case "/keyboard":
                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Презентация Антона")
                        },
                        new[]
                        {
                            new KeyboardButton("Инфо")
                        }
                    });
                    
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Кнопочное меню заказывали? Получите!)", replyMarkup: replyKeyboard);
                    break;
                case "Презентация Антона":
                    await Bot.SendTextMessageAsync(message.Chat.Id, "https://clck.ru/MpqJ7");
                    break;
                case "Инфо":
                    var keyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl("Егорка", "https://vk.com/regorka"),
                            InlineKeyboardButton.WithUrl("Глебский", "https://vk.com/dembo_tashit")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.From.Id, "LearnSQL_bot — это бот, помогающий новичкам выучить основы синтаксиса языка SQL. Он был создан Егором и Глебом в качестве итогового кейса на семинаре по базам данных SQL. Чтобы связаться с создателями бота, используйте кнопки ниже", replyMarkup: keyboard);
                    break;
                case "ВАЛИ КАБАНА!!!":
                    await Bot.SendTextMessageAsync(message.From.Id, ConnectionWithDB.getMessages());
                    break;
                default:
                    string answer = ConnectionWithDB.WhatOperator(message.Text.ToUpper());
                    if (answer == "")
                    {
                        var response = apiAi.TextRequest(message.Text);
                        answer = response.Result.Fulfillment.Speech;
                        if (answer == "")
                            answer = "Прости, я тебя не понимаю";
                    }
                    
                    await Bot.SendTextMessageAsync(message.From.Id, answer);
                    
                    break;
            }
        }
    }
}
