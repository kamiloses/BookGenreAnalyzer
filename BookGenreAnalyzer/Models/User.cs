using Microsoft.AspNetCore.Identity;

namespace BookGenreAnalyzer.Models;

public class User : IdentityUser<int>
{
  public  string? FirstName { get; set; }
  public string? LastName { get; set; }
}