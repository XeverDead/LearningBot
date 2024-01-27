using LearningBot.Bot.Constants;
using LearningBot.Bot.Processors.Interfaces;
using LearningBot.Bot.Processors.Models;
using LearningBot.Logic.Services.Interfaces;
using LearningBot.Shared.Entities;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace LearningBot.Bot.Processors;

internal class DeleteProcessor : IProcessor
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUserService _userService;

    public DeleteProcessor(ITelegramBotClient botClient, IUserService userService)
    {
        _botClient = botClient;
        _userService = userService;
    }

    public bool IsApplicable(string input, User user, UpdateType updateType)
    {
        return user != null && input == Commands.Delete;
    }

    public async Task Process(ProcessorParameters parameters)
    {
        await _userService.DeleteById(parameters.User.Id);
        var responseText = "All your data was deleted";
        await _botClient.SendTextMessageAsync(parameters.Chat.Id, responseText);
    }
}
