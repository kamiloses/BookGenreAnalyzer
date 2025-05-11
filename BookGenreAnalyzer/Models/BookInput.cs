using Microsoft.ML.Data;

namespace BookGenreAnalyzer.Models;

public class BookInput
{
    
    [ColumnName("PredictedLabel")]
    public string PredictedGenre { get; set; }
}