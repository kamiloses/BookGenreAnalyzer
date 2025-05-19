using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;

[ApiController]
[Route("/api/[controller]")]
public class LoginController : ControllerBase
{

    private readonly UserService _userService;

    public LoginController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("/api/user/login")]
    public IActionResult LoginPage()
    {
        return Unauthorized("You are not logged in");
    }

    [HttpPost("/api/user/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            await _userService.LoginAsync(dto);
            return Ok("Login successful.");
        }
        catch (InvalidOperationException ex)
        {
            return Unauthorized(ex.Message);
        }


    }
}