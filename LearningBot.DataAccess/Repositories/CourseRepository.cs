using LearningBot.DataAccess.Repositories.Interfaces;
using LearningBot.DataAccess.Repositories.Queries;
using LearningBot.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBot.DataAccess.Repositories;

internal class CourseRepository : RepositoryBase, ICourseRepository
{
    public CourseRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<List<Course>> GetAll() => await QueryAsync<Course>(CourseQueries.GetAll);
}
