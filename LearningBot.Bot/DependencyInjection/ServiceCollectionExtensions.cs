using LearningBot.Bot.Processors;
using LearningBot.Bot.Processors.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Polling;

namespace LearningBot.Bot.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddUpdateHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUpdateHandler, UpdateHandler>();
    }

    public static void AddProcessors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IProcessor, StartProcessor>();
        serviceCollection.AddSingleton<IProcessor, RegistrationProcessor>();
        serviceCollection.AddSingleton<IProcessor, DeleteProcessor>();
    }
}
