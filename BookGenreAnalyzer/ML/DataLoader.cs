using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.ML;

public class DataLoader
{
    private readonly string _trainingPath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\Models\\generated_stories_english.tsv";

    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\Models\\generated_stories_english.zip";

    private readonly MLContext _mlContext;

    public DataLoader()
    {
        _mlContext = new MLContext(seed: 0);
    }

    public void TrainAndSaveModel()
    {
        var trainingData = _mlContext.Data.LoadFromTextFile<BookInformation>(
            _trainingPath, hasHeader: true);

        var pipeline = ProcessData();

        var trainedModel = BuildAndTrainModel(trainingData, pipeline).Fit(trainingData);

        _mlContext.Model.Save(trainedModel, trainingData.Schema, _modelFilePath);
    }

    private IEstimator<ITransformer> ProcessData()
    {
        return _mlContext.Transforms.Conversion
            .MapValueToKey(inputColumnName: "Genre", outputColumnName: "Label") 
            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "TextFragment", outputColumnName: "Features"))
            .AppendCacheCheckpoint(_mlContext);
    }
    private IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
    {
        return pipeline
            .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
            .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"))
            .AppendCacheCheckpoint(_mlContext);
    }
    public string PredictGenre(string textFragment)
    {
        ITransformer trainedModel = _mlContext.Model.Load(_modelFilePath, out var modelInputSchema);

        var predictionEngine = _mlContext.Model.CreatePredictionEngine<BookInformation, BookPrediction>(trainedModel);

        var sample = new BookInformation
        {
            Title = "", // nieużywane
            TextFragment = textFragment
        };

        var prediction = predictionEngine.Predict(sample);
        return prediction.Genre;
    }
}