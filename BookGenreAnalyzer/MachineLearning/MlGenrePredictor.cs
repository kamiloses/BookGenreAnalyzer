using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;

public class MlGenrePredictor
{
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    private MLContext _mlContext;

    public MlGenrePredictor(MLContext mlContext)
    {
        _mlContext = mlContext;
    }


    public string PredictGenre(string textFragment)
    {
        ITransformer trainedModel = _mlContext.Model.Load(_modelFilePath, out var modelInputSchema);
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<BookInformation, BookPredictionDto>(trainedModel);
        var sample = new BookInformation {TextFragment = textFragment };
         
        var prediction = predictionEngine.Predict(sample);
        return prediction.Genre;
    }
    
    
}