using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.ApiClient.Resources.Interfaces;

public interface ICourseResource
{
    Task<List<Course>> GetAll();
}
