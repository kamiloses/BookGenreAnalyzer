
using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.MachineLearning;


public class MlDataLoader
{

    private readonly MLContext _mlContext;

    public MlDataLoader()
    {
        _mlContext = new MLContext(seed: 0);
    }
    
    
    public IEstimator<ITransformer> LoadDataFromTSV()
    {
        return _mlContext.Transforms.Conversion
            .MapValueToKey(inputColumnName: "Genre", outputColumnName: "Genre") 
            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "TextFragment", outputColumnName: "TextFragment"))
            .AppendCacheCheckpoint(_mlContext);
    }
    
    
    
    
    public string GetRandomTitleByGenre(string genre)
    { 
        var dataView = _mlContext.Data.LoadFromTextFile<BookInformation>(
            "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\wwwroot\\TSVFiles\\generated_stories_english.tsv", hasHeader: true, separatorChar: '\t');

        var data = _mlContext.Data.CreateEnumerable<BookInformation>(dataView, reuseRowObject: false).ToList();

        var filtered = data
            .Where(x => string.Equals(x.Genre?.Trim(), genre.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filtered.Count == 0)
            return $"No titles found for genre: {genre}";

        var random = new Random();
        var randomTitle = filtered[random.Next(filtered.Count)].Title;

        return randomTitle;
    }

    
    
}