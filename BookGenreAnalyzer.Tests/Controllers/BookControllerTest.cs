using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BookGenreAnalyzer.Tests.Controllers;

public class BookControllerTest: IClassFixture<WebApplicationFactory<BookGenreAnalyzer.Program>>{

private readonly HttpClient _client;
private readonly UserManager<User> _userManager;
private readonly IServiceScope _scope;


public BookControllerTest(WebApplicationFactory<Program> factory)
{
    _client = factory.CreateClient();


    _scope = factory.Services.CreateScope();
    _userManager = _scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    
    
    
    
    
    
    
    List<User> users = _userManager.Users.ToList();
    foreach (var user in users)
    {
      _userManager.DeleteAsync(user);
    }

    //creating new user
    User newUser = new User() { UserName = "Kamiloses" };
    string password = "Kamiloses123!";
    Task<IdentityResult> savedUser = _userManager.CreateAsync(newUser, password);

    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine(savedUser.Result); 
    
    
    
    
    
}
    
    
    

    [Fact]
    public async Task Should_Check_If_TrainModel_Method_Executes()
    {
        Thread.Sleep(3000);
        
        Console.WriteLine("WYKONUJE SIE ");
       // LoginDto badCredentials = new LoginDto() { Username = "123", Password = "123!" };
       // var json = JsonConvert.SerializeObject(badCredentials);
        //var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response =_client.PostAsync("/api/book/train", null);
        Console.BackgroundColor = ConsoleColor.Green;
        
      //  Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    
    

}