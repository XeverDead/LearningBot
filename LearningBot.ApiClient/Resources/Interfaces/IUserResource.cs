using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.ApiClient.Resources.Interfaces;

public interface IUserResource
{
    Task<List<User>> GetAllExceptNew();

    Task Update(User user);
}
