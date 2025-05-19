using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookGenreAnalyzer.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using BookGenreAnalyzer;

namespace BookGenreAnalyzer.Tests.Controllers;

public class LoginControllerTest     : IClassFixture<WebApplicationFactory<BookGenreAnalyzer.Program>> 
{
    private readonly HttpClient _client;

    public LoginControllerTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(); 
    }
    
    [Fact]
    public async Task Should_LogIn_Successfully()
    {
        Console.WriteLine("AAAAAAAAAAAAAAA");

        LoginDto loginBody = new LoginDto(){Username = "Kamiloses",Password = "Kamiloses123!"};
        var json = JsonConvert.SerializeObject(loginBody); 
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/user/login",content);
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("AAAAAAAAAAAAAAA"+response.StatusCode);
        response.EnsureSuccessStatusCode();

    }
    
    
    
}