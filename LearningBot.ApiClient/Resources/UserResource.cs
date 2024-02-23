using LearningBot.ApiClient.Models;
using LearningBot.ApiClient.Resources.Interfaces;
using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.ApiClient.Resources;

internal class UserResource : IUserResource
{
    private readonly ApiClient _apiClient;
    private readonly ApiSettings _apiSettings;

    public UserResource(ApiClient apiClient, ApiSettings apiSettings)
    {
        _apiClient = apiClient;
        _apiSettings = apiSettings;
    }

    public async Task<List<User>> GetAllExceptNew() => await _apiClient.Get<List<User>>(GetPath());

    public async Task Update(User user) => await _apiClient.Put(GetPath(), user);

    private string GetPath() => _apiSettings.BaseUrl + _apiSettings.UserResourceSubPath;
}
