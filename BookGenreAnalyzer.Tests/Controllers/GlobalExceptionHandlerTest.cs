// using System;
// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;
// using BookGenreAnalyzer.DTOs;
// using BookGenreAnalyzer.Services;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Moq;
// using Newtonsoft.Json;
// using Xunit;
//
// namespace BookGenreAnalyzer.Tests.Controllers;
//
// public class GlobalExceptionHandlerTest : IClassFixture<WebApplicationFactory<BookGenreAnalyzer.Program>>
// {
//     private readonly Mock<UserService> _userServiceMock;
//     private readonly HttpClient _client;
//
//     public GlobalExceptionHandlerTest(WebApplicationFactory<Program> factory)
//     {
//         _userServiceMock = new Mock<UserService>();
//         _client = factory.CreateClient();
//
//     }
//
//
//     [Fact]
//     public async Task Should_Check_if_GlobalEx_Invokes()
//     {
//         LoginDto login = new LoginDto() { Username = "Kamiloses", Password = "Kamiloses123!" };
//         var json = JsonConvert.SerializeObject(login);
//         var content = new StringContent(json, Encoding.UTF8, "application/json");
//
//
//         _userServiceMock.Setup(t => t.LoginAsync(It.IsAny<LoginDto>()))
//             .ThrowsAsync(new Exception("There was Some error with 'loginAsync' Method"));
//         var response = await _client.PostAsync("/api/user/login", content);
//
//     }
// }
//
//
// //
// // /*using Microsoft.AspNetCore.Hosting;
// // using Microsoft.AspNetCore.Mvc.Testing;
// // using Microsoft.EntityFrameworkCore;
// // using Microsoft.Extensions.DependencyInjection;
// // using System.Linq;
// //
// // namespace YourAppNamespace.Tests 
// // {
// //     public class CustomWebApplicationFactory : WebApplicationFactory<Program>
// //     {
// //         protected override void ConfigureWebHost(IWebHostBuilder builder)
// //         {
// //             builder.UseEnvironment("Test");
// //
// //             builder.ConfigureServices(services =>
// //             {
// //                 var descriptor = services.SingleOrDefault(d =>
// //                     d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
// //
// //                 if (descriptor != null)
// //                 {
// //                     services.Remove(descriptor);
// //                 }
// //
// //                 services.AddDbContext<ApplicationDbContext>(options =>
// //                 {
// //                     options.UseInMemoryDatabase("DatabaseForTesting");
// //                 });
// //             });
// //         }
// //     }
// // }
// // */
// //
// //
// // }
// // }