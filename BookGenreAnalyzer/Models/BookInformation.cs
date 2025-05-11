using Microsoft.ML.Data;

namespace BookGenreAnalyzer.Models;
//https://sii.pl/blog/ml-net-uczenie-maszynowe-w-wydaniu-microsoftu/
public class BookInformation
{     
        
        [LoadColumn(0)]
        public string Id { get; set; }        
        [LoadColumn(1)]
        public string Title { get; set; }         
        [LoadColumn(2)]
        public string TextFragment { get; set; }    
        [LoadColumn(3), ColumnName("Label")]
        public string Genre { get; set; }           
        
        
        
        
        
}