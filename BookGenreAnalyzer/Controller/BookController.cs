using BookGenreAnalyzer.ML;
using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;
[Route("[controller]")]
[ApiController]
public class BookController 
{
private DataLoader _dataLoader;

public BookController(DataLoader dataLoader)
{
    _dataLoader = dataLoader;
}

public void a()
    {
        _dataLoader.DataManager();


    }
    
}