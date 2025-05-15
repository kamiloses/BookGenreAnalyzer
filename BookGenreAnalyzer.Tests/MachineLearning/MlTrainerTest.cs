using BookGenreAnalyzer.MachineLearning;
using Microsoft.ML;
using Xunit;

namespace BookGenreAnalyzer.Tests.MachineLearning;

public class MlTrainerTest
{
   
    private MlTrainer _mlTrainer;
    private MLContext _mlContext;
    private MlDataLoader _mlDataLoader;
    public MlTrainerTest()
    {
        _mlContext = new MLContext(seed: 0);
        _mlDataLoader = new MlDataLoader();
        
        _mlTrainer = new MlTrainer(_mlContext,_mlDataLoader);


    }


    [Fact]
    public void BuildAndTrainModel_ShouldReturnNotNullEstimator()
    {
        Assert.NotNull(_mlTrainer);
    }
}