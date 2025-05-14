using BookGenreAnalyzer.ML;
using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;
[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly DataLoader _dataLoader;

    public BookController(DataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }

    [HttpPost("predict")]
    public ActionResult<string> PredictGenre([FromBody] BookInputDTO request)
    {
        if (string.IsNullOrWhiteSpace(request.TextFragment))
            return BadRequest("TextFragment is required.");

        var genre = _dataLoader.PredictGenre(request.TextFragment);
        
        
        return Ok("DZIAŁA "+genre);
    }
    
    [HttpPost("train")]
    public IActionResult TrainModel()
    {
        _dataLoader.TrainAndSaveModel();
        return Ok("Model trained and saved.");
    }

    
}