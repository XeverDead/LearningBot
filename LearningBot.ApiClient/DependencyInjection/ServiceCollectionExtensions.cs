using LearningBot.ApiClient.Models;
using LearningBot.ApiClient.Resources;
using LearningBot.ApiClient.Resources.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LearningBot.ApiClient.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddResources(this IServiceCollection serviceCollection, ApiSettings apiSettings)
    {
        serviceCollection.AddSingleton(apiSettings);
        serviceCollection.AddSingleton<ApiClient>();
        serviceCollection.AddSingleton<IUserResource, UserResource>();
        serviceCollection.AddSingleton<ICourseResource, CourseResource>();
        serviceCollection.AddSingleton<IExerciseResource, ExerciseResource>();
    }
}
