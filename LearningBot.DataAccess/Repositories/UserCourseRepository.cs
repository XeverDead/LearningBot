using LearningBot.DataAccess.Repositories.Interfaces;

namespace LearningBot.DataAccess.Repositories;

internal class UserCourseRepository : RepositoryBase, IUserCourseRepository
{
    public UserCourseRepository(string connectionString)
        : base(connectionString)
    {
    }
}
