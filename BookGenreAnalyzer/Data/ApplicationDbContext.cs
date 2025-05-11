using BookGenreAnalyzer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookGenreAnalyzer.Data;

public class ApplicationDbContext :  IdentityDbContext<User, IdentityRole<int>, int>
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    
    
}