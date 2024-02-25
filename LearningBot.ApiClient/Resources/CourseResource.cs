using LearningBot.ApiClient.Models;
using LearningBot.ApiClient.Resources.Interfaces;
using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.ApiClient.Resources;

internal class CourseResource : ICourseResource
{
    private readonly ApiClient _apiClient;
    private readonly ApiSettings _apiSettings;

    public CourseResource(ApiClient apiClient, ApiSettings apiSettings)
    {
        _apiClient = apiClient;
        _apiSettings = apiSettings;
    }

    public async Task<List<Course>> GetAll() => await _apiClient.Get<List<Course>>(GetPath());

    private string GetPath() => _apiSettings.BaseUrl + _apiSettings.CourseResourceSubPath;
}
