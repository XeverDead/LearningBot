using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.DataAccess.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetByChatId(long chatId);

    Task Add(User user);

    Task Update(User user);

    Task DeleteById(int id);

    Task<List<User>> GetAllExceptNew();
}
