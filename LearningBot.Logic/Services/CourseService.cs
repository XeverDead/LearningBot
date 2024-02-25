using LearningBot.DataAccess.Repositories.Interfaces;
using LearningBot.Logic.Services.Interfaces;
using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.Logic.Services;

internal class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<Course>> GetAll() => await _courseRepository.GetAll();
}
