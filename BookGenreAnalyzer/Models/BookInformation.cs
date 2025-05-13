using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace BookGenreAnalyzer.Models;

public class BookInformation
{
    [LoadColumn(0)] 
    public string Title { get; set; }
    [LoadColumn(1)] 
    public string TextFragment { get; set; }
    [LoadColumn(2)]
    public string Genre { get; set; }
}