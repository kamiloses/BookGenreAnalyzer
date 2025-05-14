using BookGenreAnalyzer.Data;
using BookGenreAnalyzer.MachineLearning;
using BookGenreAnalyzer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MLContext>().AddSingleton<MlDataLoader>().AddSingleton<MlTrainer>().AddSingleton<MlGenrePredictor>().AddSingleton<BookGenreService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();