using Microsoft.AspNetCore.Identity;

namespace BookGenreAnalyzer.Models;

public class User : IdentityUser<int>
{
  public  string? firstName { get; set; }
  public string lastName { get; set; }
}