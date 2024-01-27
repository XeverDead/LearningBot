using LearningBot.Bot.Constants;
using LearningBot.Bot.Processors.Interfaces;
using LearningBot.Bot.Processors.Models;
using LearningBot.Bot.Utils;
using LearningBot.Logic.Services.Interfaces;
using LearningBot.Shared.Entities;
using LearningBot.Shared.Enums;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace LearningBot.Bot.Processors;

internal class RegistrationProcessor : IProcessor
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUserService _userService;

    public RegistrationProcessor(ITelegramBotClient botClient, IUserService userService)
    {
        _botClient = botClient;
        _userService = userService;
    }

    public bool IsApplicable(string input, User user, UpdateType updateType)
    {
        var isApplicable = user?.Status == UserStatus.New && (updateType == UpdateType.CallbackQuery
            && (input == Commands.ShortRegistration || input == Commands.FullRegistration) || !input.IsCommand());

        return isApplicable;
    }

    public async Task Process(ProcessorParameters parameters)
    {
        string responseText;
        if (parameters.Input == Commands.ShortRegistration)
        {
            parameters.User.Forename = parameters.Chat.FirstName;
            parameters.User.Surname = parameters.Chat.LastName;
            await _userService.Update(parameters.User);
            responseText = "Enter your email address";
        }
        else if (parameters.Input == Commands.FullRegistration)
        {
            responseText = "Enter your forename";
        }
        else
        {
            if (parameters.User.Forename == null)
            {
                parameters.User.Forename = parameters.Input;
                responseText = "Enter your surname";
            }
            else if (parameters.User.Surname == null)
            {
                parameters.User.Surname = parameters.Input;
                responseText = "Enter your email address";
            }
            else if(parameters.Input.IsValidEmail())
            {
                parameters.User.Email = parameters.Input;
                parameters.User.Status = UserStatus.Applied;
                responseText = "You are registered";
            }
            else
            {
                responseText = "Entered email is invalid. Try again";
            }

            await _userService.Update(parameters.User);
        }

        await _botClient.SendTextMessageAsync(parameters.Chat.Id, responseText);
    }
}
