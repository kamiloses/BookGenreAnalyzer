using Microsoft.ML.Data;

namespace BookGenreAnalyzer.DTOs;

public class BookPredictionDto
{
    [ColumnName("PredictedLabel")]
    public string? Genre { get; set; }
   
}