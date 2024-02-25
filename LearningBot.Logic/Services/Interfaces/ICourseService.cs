using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.Logic.Services.Interfaces;

public interface ICourseService
{
    Task<List<Course>> GetAll();
}
