using LearningBot.DataAccess.Repositories.Interfaces;

namespace LearningBot.DataAccess.Repositories;

internal class ExerciseRepository : RepositoryBase, IExerciseRepository
{
    public ExerciseRepository(string connectionString) : base(connectionString)
    {
    }
}
