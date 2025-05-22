using BookGenreAnalyzer.Controller;
using BookGenreAnalyzer.Data;
using BookGenreAnalyzer.Exceptions;
using BookGenreAnalyzer.MachineLearning;
using BookGenreAnalyzer.Models;
using BookGenreAnalyzer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace BookGenreAnalyzer
{
    public class Program  //integration tests
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            
            builder.Services.AddScoped<UserSeed>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            builder.Services
                .AddSingleton<MLContext>()
                .AddSingleton<MlDataLoader>()
                .AddSingleton<MlTrainer>()
                .AddSingleton<MlGenrePredictor>()
                .AddSingleton<BookGenreService>()
                .AddScoped<UserService>()
                .AddScoped<LoginController>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/api/user/login";
            });

            var app = builder.Build();

            
            app.UseMiddleware<GlobalExceptionMiddleware>();
            //running UserSeed
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<UserSeed>();
                await seeder.seedTheUser();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
