using Microsoft.ML.Data;

namespace BookGenreAnalyzer.Models;

public class BookInformation
{     
        
        [LoadColumn(1)]
        public string Id { get; set; }        
        [LoadColumn(1)]
        public string Title { get; set; }         
        [LoadColumn(1)]
        public string TextFragment { get; set; }    
        [LoadColumn(1)]
        public string Genre { get; set; }           
        [LoadColumn(1)]
        public string Description { get; set; }     
}