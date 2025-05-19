using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Identity;

namespace BookGenreAnalyzer.Services;

public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;


    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);
        if (user == null)
            throw new InvalidOperationException("Invalid username or password");

        var result =
            await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new InvalidOperationException("Invalid username or password");
    }
}