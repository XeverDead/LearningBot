using LearningBot.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningBot.UI.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddViewModels(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<UserListViewModel>();
    }
}
