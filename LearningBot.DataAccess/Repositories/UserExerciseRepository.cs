using LearningBot.DataAccess.Repositories.Interfaces;

namespace LearningBot.DataAccess.Repositories;

internal class UserExerciseRepository : RepositoryBase, IUserExerciseRepository
{
    public UserExerciseRepository(string connectionString)
        : base(connectionString)
    {
    }
}
