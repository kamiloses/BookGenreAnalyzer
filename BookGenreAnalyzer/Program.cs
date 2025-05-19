using BookGenreAnalyzer.Controller;
using BookGenreAnalyzer.Data;
using BookGenreAnalyzer.MachineLearning;
using BookGenreAnalyzer.Models;
using BookGenreAnalyzer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MLContext>().AddSingleton<MlDataLoader>().AddSingleton<MlTrainer>().AddSingleton<MlGenrePredictor>().AddSingleton<BookGenreService>().AddScoped<UserService>().AddScoped<LoginController>();

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

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();