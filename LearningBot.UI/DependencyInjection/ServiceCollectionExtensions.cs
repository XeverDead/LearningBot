using LearningBot.UI.ViewModels;
using LearningBot.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LearningBot.UI.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddViewModels(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<UserListViewModel>();
        serviceCollection.AddSingleton<UserViewModel>();
        serviceCollection.AddSingleton<CourseListViewModel>();
    }

    public static void AddViews(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<UserListView>();
        serviceCollection.AddSingleton<UserView>();
        serviceCollection.AddSingleton<CourseListView>();
    }
}
