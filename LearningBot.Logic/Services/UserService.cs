using LearningBot.DataAccess.Repositories.Interfaces;
using LearningBot.Logic.Services.Interfaces;
using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.Logic.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByChatId(long chatId) => await _userRepository.GetByChatId(chatId);

    public async Task Add(User user) => await _userRepository.Add(user);

    public async Task Update(User user) => await _userRepository.Update(user);

    public async Task DeleteById(int id) => await _userRepository.DeleteById(id);

    public async Task<List<User>> GetAllExceptNew() => await _userRepository.GetAllExceptNew();
}
