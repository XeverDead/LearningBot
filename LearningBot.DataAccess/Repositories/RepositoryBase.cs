using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBot.DataAccess.Repositories;

internal abstract class RepositoryBase
{
    protected string ConnectionString { get; }

    public RepositoryBase(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters = null)
    {
        using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        var result = await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
        return result;
    }

    protected async Task ExecuteAsync(string query, object parameters = null)
    {
        using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(query, parameters);
    }

    protected async Task<List<T>> QueryAsync<T>(string query, object parameters = null)
    {
        using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        var result = await connection.QueryAsync<T>(query, parameters);
        return result.ToList();
    }
}
