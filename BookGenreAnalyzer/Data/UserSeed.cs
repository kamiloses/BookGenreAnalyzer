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
    var users = _userManager.Users.ToList();
    foreach (var user in users)
    {
       await _userManager.DeleteAsync(user);
    }
    

    
    
        User newUser = new User() { UserName = "Kamiloses" };
         string password = "Kamiloses123!";
            Task<IdentityResult> savedUser= _userManager.CreateAsync(newUser, password);
            Console.BackgroundColor = ConsoleColor.Green;      
            Console.WriteLine(savedUser.Result);
        

    }
}