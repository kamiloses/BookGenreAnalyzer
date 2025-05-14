using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;

public class MLPredicotService
{
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    private MLContext _mlContext;

    public MLPredicotService(MLContext mlContext)
    {
        _mlContext = mlContext;
    }


    public string PredictGenre(string textFragment)
    {
        ITransformer trainedModel = _mlContext.Model.Load(_modelFilePath, out var modelInputSchema);

        var predictionEngine = _mlContext.Model.CreatePredictionEngine<BookInformation, BookPredictionDto>(trainedModel);

        var sample = new BookInformation
        {
            Title = "", 
            TextFragment = textFragment
        };

        var prediction = predictionEngine.Predict(sample);
        Console.WriteLine($"Predicted genre: {prediction.Genre}");
        return prediction.Genre;
    }
    
    
}