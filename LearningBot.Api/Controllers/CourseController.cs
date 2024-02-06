using LearningBot.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearningBot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
}
