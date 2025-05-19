using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Identity;

namespace BookGenreAnalyzer.Data;

public class UserSeed
{

    private readonly UserManager<User> _userManager;


    public UserSeed(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task seedTheUser()
    {
        string username = "Kamiloses";
        string password = "Kamiloses123!";


        var existingUser = await _userManager.FindByEmailAsync(username);

        if (existingUser == null)
        {
            var user = new User
            {
                UserName = username,
            };

            var result = await _userManager.CreateAsync(user, password);




            Task<IdentityResult> savedUser = _userManager.CreateAsync(user, password);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(savedUser.Result);


        }

    }
}