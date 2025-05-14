using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.MachineLearning;
using BookGenreAnalyzer.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;
[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookGenreService _bookGenreService;

    public BookController(BookGenreService bookGenreService)
    {
        _bookGenreService = bookGenreService;
    }


    [HttpPost("predict")]
    public ActionResult<string> PredictGenre([FromBody] BookInputDto request)
    {
        if (string.IsNullOrWhiteSpace(request.TextFragment))
            return BadRequest("TextFragment is required.");

        var genre = _bookGenreService.PredictGenre(request.TextFragment);
        
        
        return Ok("Predicted genre: "+genre);
    }
    
    [HttpPost("train")]
    public IActionResult TrainModel()
    {
        _bookGenreService.TrainModel();
        return Ok("Model trained and saved.");
    }


    [HttpGet("recommend/{genre}")]
    public String recommendBook([FromRoute] String genre)
    {
       return  _bookGenreService.GetRandomTitleByGenre(genre);

    }
    
    
}