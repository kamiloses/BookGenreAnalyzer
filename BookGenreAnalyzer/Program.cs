using BookGenreAnalyzer.Data;
using BookGenreAnalyzer.ML;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DataLoader>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();