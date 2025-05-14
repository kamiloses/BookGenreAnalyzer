using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;


public class DataLoader
{
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    private readonly MLContext _mlContext;

    public DataLoader()
    {
        _mlContext = new MLContext(seed: 0);
    }
    

    internal IEstimator<ITransformer> ProcessData()
    {
        return _mlContext.Transforms.Conversion
            .MapValueToKey(inputColumnName: "Genre", outputColumnName: "Label") 
            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "TextFragment", outputColumnName: "Features"))
            .AppendCacheCheckpoint(_mlContext);
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