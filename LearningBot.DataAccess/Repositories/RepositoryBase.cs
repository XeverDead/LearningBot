namespace LearningBot.DataAccess.Repositories;

internal abstract class RepositoryBase
{
    protected string ConnectionString { get; }

    public RepositoryBase(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
