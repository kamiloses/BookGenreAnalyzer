using System.ComponentModel.DataAnnotations.Schema;

namespace BookGenreAnalyzer.Models;

public class BookPrediction
{
    [Column("PredictedLabel")]
    public string Genre { get; set; }
}