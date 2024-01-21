using LearningBot.Bot.DependencyInjection;
using LearningBot.DataAccess.DependencyInjection;
using LearningBot.Logic.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace LearningBot.Bot;

internal class Program
{
    public static async Task Main()
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        var botSettings = GetBotSettings();
        var botClient = new TelegramBotClient(botSettings.Token);
        var serviceProvider = SetupServiceProvider(botSettings.ConnectionString);
        var updateHandler = serviceProvider.GetRequiredService<IUpdateHandler>();
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new UpdateType[] { UpdateType.Message },
            ThrowPendingUpdates = true,
        };

        var bot = await botClient.GetMeAsync();
        Console.WriteLine($"Start listening for @{bot.Username}");
        botClient.StartReceiving(updateHandler, receiverOptions, cancellationTokenSource.Token);

        Console.ReadLine();

        cancellationTokenSource.Cancel();
    }

    private static IServiceProvider SetupServiceProvider(string connectionString)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddRepositories(connectionString);
        serviceCollection.AddServices();
        serviceCollection.AddUpdateHandler();
        return serviceCollection.BuildServiceProvider();
    }

    private static BotSettings GetBotSettings()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var botSettingsSection = config.GetRequiredSection(nameof(BotSettings));
        var botSettings = new BotSettings
        {
            Token = botSettingsSection[nameof(BotSettings.Token)],
            ConnectionString = botSettingsSection[nameof(BotSettings.ConnectionString)],
        };

        return botSettings;
    }
}