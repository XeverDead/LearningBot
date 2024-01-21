using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace LearningBot.Bot;

internal class UpdateHandler : IUpdateHandler
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message.Text == null)
        {
            return;
        }

        Console.WriteLine($"Received a {update.Message.Text} message in chat {update.Message.Chat.Id}");

        var replyMessage = $"You said\n{update.Message.Text}";
        await botClient.SendTextMessageAsync(update.Message.Chat.Id, replyMessage, cancellationToken: cancellationToken);
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
