using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;

public class MLTraining
{
    
    private readonly string _trainingPath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\TSVFiles\\generated_stories_english.tsv";
   
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    
    
    
    private MLContext _mlContext;
    private MLPredicotService _predicotService;
    private DataLoader _dataLoader;

    public MLTraining(MLContext mlContext, MLPredicotService predicotService, DataLoader dataLoader)
    {
        _mlContext = mlContext;
        _predicotService = predicotService;
        _dataLoader = dataLoader;
    }


    private IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
    {
        return pipeline
            .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
            .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"))
            .AppendCacheCheckpoint(_mlContext);
    }
    
      

    public void TrainAndSaveModel()
    {  
        var trainingData = _mlContext.Data.LoadFromTextFile<BookInformation>(
            _trainingPath, hasHeader: true);

        var pipeline = _dataLoader.LoadDataFromTSV();

        var trainedModel = BuildAndTrainModel(trainingData, pipeline).Fit(trainingData);

        _mlContext.Model.Save(trainedModel, trainingData.Schema, _modelFilePath);
    }
}