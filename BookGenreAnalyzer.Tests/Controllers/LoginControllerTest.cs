using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookGenreAnalyzer.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookGenreAnalyzer.Tests.Controllers;

public class LoginControllerTest : IClassFixture<WebApplicationFactory<BookGenreAnalyzer.Program>>, IDisposable
{
    private readonly HttpClient _client;
    private readonly UserManager<User> _userManager;
    private readonly IServiceScope _scope;


    public LoginControllerTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();


        _scope = factory.Services.CreateScope();
        _userManager = _scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    }

    public void Dispose()
    {
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
    public async Task Should_LogIn_Successfully()
    {
        LoginDto loginBody = new LoginDto() { Username = "Kamiloses", Password = "Kamiloses123!" };
        var json = JsonConvert.SerializeObject(loginBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/user/login", content);
        Console.BackgroundColor = ConsoleColor.Green;


        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Login successful.", responseString);
    }


    [Fact]
    public async Task Should_LogIn_UnSuccessfully()
    {
        LoginDto badCredentials = new LoginDto() { Username = "123", Password = "123!" };
        var json = JsonConvert.SerializeObject(badCredentials);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/user/login", content);
        Console.BackgroundColor = ConsoleColor.Green;


        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}