using BookGenreAnalyzer.Data;
using BookGenreAnalyzer.MachineLearning;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddSingleton<DataLoader>();
builder.Services.AddSingleton<MLTraining>();
builder.Services.AddSingleton<MLContext>();
builder.Services.AddSingleton<MLPredicotService>();
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();