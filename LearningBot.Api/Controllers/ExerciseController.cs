using LearningBot.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearningBot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }
}
