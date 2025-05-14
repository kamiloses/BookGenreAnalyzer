using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;

public class MLTraining
{
    
    private readonly string _trainingPath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\TSVFiles\\generated_stories_english.tsv";
   
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    
    
    
    private DataLoader _dataLoader;
    private MLContext _mlContext;
    
    public MLTraining(DataLoader dataLoader, MLContext mlContext)
    {
        _dataLoader = dataLoader;
        _mlContext = mlContext;
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

        var pipeline = _dataLoader.ProcessData();

        var trainedModel = BuildAndTrainModel(trainingData, pipeline).Fit(trainingData);

        _mlContext.Model.Save(trainedModel, trainingData.Schema, _modelFilePath);
    }
}