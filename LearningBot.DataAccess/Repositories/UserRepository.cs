using LearningBot.DataAccess.Repositories.Interfaces;
using LearningBot.DataAccess.Repositories.Queries;
using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.DataAccess.Repositories;

internal class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<User> GetByChatId(long chatId) => await QueryFirstOrDefaultAsync<User>(UserQueries.GetByChatId, new { ChatId = chatId });

    public async Task Add(User user)
    {
        var parameters = new { user.ChatId, user.Forename, user.Surname, user.Email, Status = (int)user.Status, user.LanguageCode };
        await ExecuteAsync(UserQueries.Add, parameters);
    }

    public async Task Update(User user)
    {
        var parameters = new { user.ChatId, user.Forename, user.Surname, user.Email, Status = (int)user.Status, user.LanguageCode, user.Id };
        await ExecuteAsync(UserQueries.Update, parameters);
    }

    public async Task DeleteById(int id) => await ExecuteAsync(UserQueries.DeleteById, new { Id = id });

    public async Task<List<User>> GetAllExceptNew() => await QueryAsync<User>(UserQueries.GetAllExceptNew);
}
