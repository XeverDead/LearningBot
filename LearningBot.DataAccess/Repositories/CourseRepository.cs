using LearningBot.DataAccess.Repositories.Interfaces;

namespace LearningBot.DataAccess.Repositories;

internal class CourseRepository : RepositoryBase, ICourseRepository
{
    public CourseRepository(string connectionString) : base(connectionString)
    {
    }
}
