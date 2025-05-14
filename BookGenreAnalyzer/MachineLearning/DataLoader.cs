
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;


public class DataLoader
{

    private readonly MLContext _mlContext;

    public DataLoader()
    {
        _mlContext = new MLContext(seed: 0);
    }
    
    
    internal IEstimator<ITransformer> LoadDataFromTSV()
    {
        return _mlContext.Transforms.Conversion
            .MapValueToKey(inputColumnName: "Genre", outputColumnName: "Label") 
            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "TextFragment", outputColumnName: "Features"))
            .AppendCacheCheckpoint(_mlContext);
    }
    
}