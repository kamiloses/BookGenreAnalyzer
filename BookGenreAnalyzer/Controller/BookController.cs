using BookGenreAnalyzer.DTOs;
using BookGenreAnalyzer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;
[Route("/api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookGenreService _bookGenreService;
//todo zobacz czy gdzieś handlera nie wrzucic
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
    [Authorize]
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