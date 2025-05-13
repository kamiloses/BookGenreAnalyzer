using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.ML;

public class DataLoader
{


    public DataLoader()
    {
        
        string _trainingPath =
            "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\Models\\generated_stories_english.tsv";
        string _modelFilePath =
            "C:\\Users\\kamil\\RiderProjects\\BookGenreAnalyzer\\BookGenreAnalyzer\\Models\\generated_stories_english.zip";

        MLContext _mlContext = new MLContext(seed:0);
        IDataView _trainiDataView=_mlContext.Data.LoadFromTextFile<BookInformation>(_trainingPath, hasHeader: true);    
    
        
        
        //2 czesc

        IEstimator<ITransformer> ProcessData()
        {
            var pipeline=_mlContext.Transforms.Conversion.MapValueToKey(inputColumnName: "Genre",outputColumnName:"Label")//Mówie maszynie czego ma sie nauczyć, co zwracać
                .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName:"TextFragment",outputColumnName:"Features"))//Na jego podstawie model ma przewidzieć gatunek
                //.Append(_mlContext.Transforms.Concatenate())
                .AppendCacheCheckpoint(_mlContext);

            return pipeline;

        }

        // IEstimator<ITransformer> BuildAndTrainModel(IDataView dataView,IEstimator<ITransformer> pipeline)
        // {
        //     var trainingPipeline = pipeline.Append();
        //
        //
        // }
        
        
        
    }
    
    
    
    
    
    

}



