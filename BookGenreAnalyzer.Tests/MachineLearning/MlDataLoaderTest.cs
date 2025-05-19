using BookGenreAnalyzer.MachineLearning;
using JetBrains.Annotations;
using Microsoft.ML;
using Xunit;

namespace BookGenreAnalyzer.Tests.MachineLearning;

//[TestSubject(typeof(MlDataLoader))]
public class MlDataLoaderTest
{
    private readonly MlDataLoader _mlDataLoader;

    public MlDataLoaderTest()
    {
        _mlDataLoader = new MlDataLoader();
    }
    
    [Fact]
    public void Should_Load_Data_From_TSV_File()
    {
        IEstimator<ITransformer> loadedFile = _mlDataLoader.LoadDataFromTSV();
        Assert.NotNull(loadedFile);
    }





    
    
    
}