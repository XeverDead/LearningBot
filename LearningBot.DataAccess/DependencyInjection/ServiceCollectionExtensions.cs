using LearningBot.DataAccess.Repositories;
using LearningBot.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LearningBot.DataAccess.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddSingleton<IUserRepository>(_ => new UserRepository(connectionString));
        serviceCollection.AddSingleton<ICourseRepository>(_ => new CourseRepository(connectionString));
        serviceCollection.AddSingleton<IExerciseRepository>(_ => new ExerciseRepository(connectionString));
        serviceCollection.AddSingleton<IUserCourseRepository>(_ => new UserCourseRepository(connectionString));
        serviceCollection.AddSingleton<IUserExerciseRepository>(_ => new UserExerciseRepository(connectionString));
        serviceCollection.AddSingleton<ICourseExerciseRepository>(_ => new CourseExerciseRepository(connectionString));
    }
}
