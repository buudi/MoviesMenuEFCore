namespace MoviesMenuEFCore.Models;

public class Movie(string? Title, string? Director, string? Genre, int? ReleaseYear, decimal? Price)
{
    public int? Id { get; set; }
    public string? Title { get; set; } = Title;
    public string? Director { get; set; } = Director;
    public int? ReleaseYear { get; set; } = ReleaseYear;
    public string? Genre { get; set; } = Genre;
    public decimal? Price { get; set; } = Price;
}
