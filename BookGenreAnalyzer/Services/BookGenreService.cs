using BookGenreAnalyzer.MachineLearning;

namespace BookGenreAnalyzer.Services;

public class BookGenreService
{
    private readonly MlGenrePredictor _mlPredictor;
    private readonly MlTrainer _mlTrainer;
    private readonly MlDataLoader _mlDataLoader;

    public BookGenreService(MlGenrePredictor mlPredictor, MlTrainer mlTrainer, MlDataLoader mlDataLoader)
    
    {
        _mlPredictor = mlPredictor;
        _mlTrainer = mlTrainer;
        _mlDataLoader = mlDataLoader;
    }

    public string PredictGenre(string textFragment)
    {
        return _mlPredictor.PredictGenre(textFragment);
    }

    public void TrainModel()
    {
        _mlTrainer.TrainAndSaveModel();
    }

    public string GetRandomTitleByGenre(string genre)
    {
        return _mlDataLoader.GetRandomTitleByGenre(genre);
    }
}