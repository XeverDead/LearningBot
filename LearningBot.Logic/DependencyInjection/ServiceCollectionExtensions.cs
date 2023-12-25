using LearningBot.Logic.Services;
using LearningBot.Logic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LearningBot.Logic.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton<ICourseService, CourseService>();
        serviceCollection.AddSingleton<IExerciseService, ExerciseService>();
    }
}
