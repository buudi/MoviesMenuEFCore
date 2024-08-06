using Microsoft.EntityFrameworkCore;
using MoviesMenuEFCore.Models;

namespace MoviesMenuEFCore.Contexts;

internal class MyBootcampDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MyBootcamp;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    public List<Movie> GetInitialMovies()
    {
        return Movies.ToList();
    }   
}
