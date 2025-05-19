using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace BookGenreAnalyzer.Tests.Controllers;

public class BookControllerTest : IClassFixture<WebApplicationFactory<BookGenreAnalyzer.Program>>
{
    private readonly HttpClient _client;
    private readonly UserManager<User> _userManager;
    private readonly IServiceScope _scope;


    public BookControllerTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();


        _scope = factory.Services.CreateScope();
        _userManager = _scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    }


    [Fact]
    public async Task Should_Check_If_TrainModel_Method_Executes()
    {
        LoginDto login = new LoginDto() { Username = "Kamiloses", Password = "Kamiloses123!" };

        await BeforeEachTest(login.Username, login.Password);

        var json = JsonConvert.SerializeObject(login);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/user/login", content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseV2 = await _client.PostAsync("/api/book/train", null);
       string responseBody = await responseV2.Content.ReadAsStringAsync();
        
        
        Assert.Equal(HttpStatusCode.OK, responseV2.StatusCode);
        Assert.Equal("Model trained and saved.",responseBody );
    }


    [Fact]
    public async Task Should_Check_If_RecommendBook_Method_Executes()
    {
        string genre = "commedy";
        
        var response = await _client.GetAsync("/api/book/recommend/"+genre);
        
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response);
    }
    
    
    
    
    

    public async Task BeforeEachTest(string username, string password)
    {
        List<User> users = _userManager.Users.ToList();
        foreach (var user in users)
        {
            await _userManager.DeleteAsync(user);
        }

        //creating new user
        User newUser = new User() { UserName = username };
        await _userManager.CreateAsync(newUser, password);

        await Task.Delay(500);
    }
}