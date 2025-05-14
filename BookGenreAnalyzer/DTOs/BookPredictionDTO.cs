using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.ML.Data;

namespace BookGenreAnalyzer.Models;

public class BookPredictionDTO
{
    [ColumnName("PredictedLabel")]
    public string Genre { get; set; }
}