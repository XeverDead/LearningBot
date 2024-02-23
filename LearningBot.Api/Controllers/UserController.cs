using LearningBot.Logic.Services.Interfaces;
using LearningBot.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearningBot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExceptNew()
    {
        var users = await _userService.GetAllExceptNew();
        return Ok(users);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] User user)
    {
        await _userService.Update(user);
        return Ok();
    }
}
