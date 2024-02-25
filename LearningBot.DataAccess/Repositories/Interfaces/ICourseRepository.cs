using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.DataAccess.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<List<Course>> GetAll();
}
