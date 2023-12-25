using LearningBot.DataAccess.Repositories.Interfaces;

namespace LearningBot.DataAccess.Repositories;

internal class CourseExerciseRepository : RepositoryBase, ICourseExerciseRepository
{
    public CourseExerciseRepository(string connectionString)
        : base(connectionString)
    {
    }
}
