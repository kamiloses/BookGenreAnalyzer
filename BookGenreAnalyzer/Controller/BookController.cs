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
    private readonly MLPredicotService _predicotService;

    public BookController(DataLoader dataLoader, MLTraining mlTraining, MLPredicotService predicotService)
    {
        _dataLoader = dataLoader;
        _mlTraining = mlTraining;
        _predicotService = predicotService;
    }

    [HttpPost("predict")]
    public ActionResult<string> PredictGenre([FromBody] BookInputDto request)
    {
        if (string.IsNullOrWhiteSpace(request.TextFragment))
            return BadRequest("TextFragment is required.");

        var genre = _predicotService.PredictGenre(request.TextFragment);
        
        
        return Ok("DZIAŁA "+genre);
    }
    
    [HttpPost("train")]
    public IActionResult TrainModel()
    {
        _mlTraining.TrainAndSaveModel();
        return Ok("Model trained and saved.");
    }


    [HttpGet("recommend/{genre}")]
    public String recommendBook([FromRoute] String genre)
    {
       return _mlTraining.GetRandomTitleByGenre(genre);

    }
    
    
}