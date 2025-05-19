using BookGenreAnalyzer.MachineLearning;
using Microsoft.ML;
using Xunit;

namespace BookGenreAnalyzer.Tests.MachineLearning;

public class MlGenrePredictorTest
{
    private readonly string _modelFilePath =
        "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\ZIPFiles\\generated_stories_english.zip";

    
    private MLContext _mlContext;
    private MlGenrePredictor _mlGenrePredictor;

    public MlGenrePredictorTest()
    {
        _mlContext = new MLContext();
        _mlGenrePredictor = new MlGenrePredictor(_mlContext);
    }


    [Fact]
    public void Should_Check_PredictGenre_Method()
    {
        
        Assert.NotNull(_mlGenrePredictor.PredictGenre("ABC"));
        
    }
    
    
}