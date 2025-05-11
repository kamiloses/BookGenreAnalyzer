using BookGenreAnalyzer.Models;
using Microsoft.ML;

namespace BookGenreAnalyzer.ML;

public class DataLoader
{
    private static string filePath = "";



//Pozwolą nam one na rożne sposoby ocenić, jak dobrze radzi sobie nasz klasyfikator.
    public void dataManager() {
        var mlContext = new MLContext(42);
        var data = mlContext.Data.LoadFromTextFile<BookInformation>(filePath, separatorChar: ',', hasHeader: true);
        var splitDataView = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
        
        
        
        var map = new Dictionary<string, bool> { { "M", true }, { "F", false } };
        var pipeline = mlContext.Transforms.Conversion.MapValue("Label", map)
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Species", outputColumnName: "SpeciesFeaturized"))
            .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Country", outputColumnName: "CountryFeaturized"))
            .Append(mlContext.Transforms.Concatenate("Features", "SpeciesFeaturized", "CountryFeaturized", "BeakLengthCulmen","BeakLengthNares","BeakWidth", "BeakDepth", "TarsusLength", "WingLength", "KippsDistance", "SecondaryLength", "HandWingIndex", "TailLength"))
            .Append(mlContext.BinaryClassification.Trainers.LinearSvm(labelColumnName: "Label", featureColumnName: "Features")); //todo zobacz metode związaną z klasą trainers bo mogą być inne
        
        
        //Trenowanie modelu
        var model = pipeline.Fit(splitDataView.TrainSet);
    }
    
}



