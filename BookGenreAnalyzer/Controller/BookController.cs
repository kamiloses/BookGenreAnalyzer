using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.MachineLearning;
using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;
[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly DataLoader _dataLoader;
    private readonly MLTraining _mlTraining;

    public BookController(DataLoader dataLoader, MLTraining mlTraining)
    {
        _dataLoader = dataLoader;
        _mlTraining = mlTraining;
    }

    [HttpPost("predict")]
    public ActionResult<string> PredictGenre([FromBody] BookInputDto request)
    {
        if (string.IsNullOrWhiteSpace(request.TextFragment))
            return BadRequest("TextFragment is required.");

        var genre = _dataLoader.PredictGenre(request.TextFragment);
        
        
        return Ok("DZIAŁA "+genre);
    }
    
    [HttpPost("train")]
    public IActionResult TrainModel()
    {
        _mlTraining.TrainAndSaveModel();
        return Ok("Model trained and saved.");
    }

    
}