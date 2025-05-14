using Microsoft.ML.Data;

namespace BookGenreAnalyzer.DTOs;

public class BookPredictionDto
{
    [ColumnName("PredictedLabel")]
    public string? Genre { get; set; }
    //There was some error with returning book's genre
}