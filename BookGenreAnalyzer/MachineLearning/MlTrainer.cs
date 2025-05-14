using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;

public class MlTrainer
{
    
    private readonly string _trainingPath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\TSVFiles\\generated_stories_english.tsv";
   
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    
    
    
    private MLContext _mlContext;
    private MlDataLoader _mlDataLoader;

    public MlTrainer(MLContext mlContext, MlDataLoader mlDataLoader)
    {
        _mlContext = mlContext;
        _mlDataLoader = mlDataLoader;
    }


    private IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
    {
        return pipeline
            .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Genre", "TextFragment"))
            .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"))
            .AppendCacheCheckpoint(_mlContext);
    }
    
      

    public void TrainAndSaveModel()
    {  
        var trainingData = _mlContext.Data.LoadFromTextFile<BookInformation>(
            _trainingPath, hasHeader: true);

        var pipeline = _mlDataLoader.LoadDataFromTSV();

        var trainedModel = BuildAndTrainModel(trainingData, pipeline).Fit(trainingData);

        _mlContext.Model.Save(trainedModel, trainingData.Schema, _modelFilePath);
    }
}