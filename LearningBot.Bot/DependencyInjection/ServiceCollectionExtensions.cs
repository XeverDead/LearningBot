using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Polling;

namespace LearningBot.Bot.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddUpdateHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUpdateHandler, UpdateHandler>();
    }
}
