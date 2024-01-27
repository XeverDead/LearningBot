using LearningBot.Bot.Processors.Interfaces;
using LearningBot.Bot.Processors.Models;
using LearningBot.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace LearningBot.Bot;

internal class UpdateHandler : IUpdateHandler
{
    private readonly IUserService _userService;
    private readonly IEnumerable<IProcessor> _processors;

    public UpdateHandler(IUserService userService, IEnumerable<IProcessor> processors)
    {
        _userService = userService;
        _processors = processors;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var chat = update.Message?.Chat ?? update.CallbackQuery.Message.Chat;
        var user = await _userService.GetByChatId(chat.Id);
        var input = update.Message?.Text ?? update.CallbackQuery.Data;
        var languageCode = update.Message?.From.LanguageCode ?? update.CallbackQuery.From.LanguageCode;
        foreach (var processor in _processors)
        {
            var isApplicable = processor.IsApplicable(input, user, update.Type);
            if (isApplicable)
            {
                var parameters = new ProcessorParameters
                {
                    User = user,
                    Input = input,
                    Chat = chat,
                    LanguageCode = languageCode,
                };

                await processor.Process(parameters);
                return;
            }
        }
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ApiRequestException apiRequestException)
        {
            Console.WriteLine($"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}");
        }
        else
        {
            Console.WriteLine(exception.Message);
        }

        return Task.CompletedTask;
    }
}
