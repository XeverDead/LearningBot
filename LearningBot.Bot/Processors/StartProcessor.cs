using LearningBot.Bot.Constants;
using LearningBot.Bot.Processors.Interfaces;
using LearningBot.Bot.Processors.Models;
using LearningBot.Logic.Services.Interfaces;
using LearningBot.Shared.Entities;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace LearningBot.Bot.Processors;

internal class StartProcessor : IProcessor
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUserService _userService;

    public StartProcessor(ITelegramBotClient botClient, IUserService userService)
    {
        _botClient = botClient;
        _userService = userService;
    }

    public bool IsApplicable(string input, User user, UpdateType updateType)
    {
        return input == Commands.Start && user == null;
    }

    public async Task Process(ProcessorParameters parameters)
    {
        var user = new User
        {
            ChatId = parameters.Chat.Id,
            LanguageCode = parameters.LanguageCode,
        };

        await _userService.Add(user);

        var responseText = "Welcome to learning bot.\n";
        if (!string.IsNullOrWhiteSpace(parameters.Chat.FirstName) && !string.IsNullOrWhiteSpace(parameters.Chat.LastName))
        {
            responseText += "Do you want to use name from your profile?";
            await _botClient.SendTextMessageAsync(parameters.Chat.Id, responseText, replyMarkup: GetRegistrationKeyboardMarkup());
        }
        else
        {
            responseText += "Enter your forename";
            await _botClient.SendTextMessageAsync(parameters.Chat.Id, responseText);
        }
    }

    private static InlineKeyboardMarkup GetRegistrationKeyboardMarkup()
    {
        var result = new InlineKeyboardMarkup(new InlineKeyboardButton[][]
        {
            new InlineKeyboardButton[]
            {
                InlineKeyboardButton.WithCallbackData("Yes", Commands.ShortRegistration),
                InlineKeyboardButton.WithCallbackData("No", Commands.FullRegistration),
            },
        });

        return result;
    }
}
