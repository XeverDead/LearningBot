using LearningBot.DataAccess.Repositories.Interfaces;

namespace LearningBot.DataAccess.Repositories;

internal class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(string connectionString)
        : base(connectionString)
    {
    }
}
