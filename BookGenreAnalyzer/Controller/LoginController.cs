using Microsoft.AspNetCore.Mvc;

namespace BookGenreAnalyzer.Controller;
[ApiController]
[Route("/api/[controller]")]
public class LoginController:ControllerBase {

    
    
    [HttpGet("/api/user/login")]
    public ForbidResult LoginPage()
    {
        return Forbid("You are not logged in");
    }


    public ActionResult Login()
    {



        return Content("");
    }
    
    
    
}