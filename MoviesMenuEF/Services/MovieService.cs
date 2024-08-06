﻿using MoviesMenuEFCore.Contexts;
using MoviesMenuEFCore.Models;

namespace MoviesMenuEFCore.Services;

internal class MovieService
{
    private MyBootcampDbContext _dbContext = new();
    private List<Movie> _movies = [];

    public MovieService() => updateInitialMoviesList();

    public void SetDbContext(MyBootcampDbContext dbContext)
    {
        _dbContext = dbContext;
        updateInitialMoviesList();
    }

    public void updateInitialMoviesList()
    {
        List<Movie> initialMovies = _dbContext.GetInitialMovies();
        _movies = initialMovies;
    }

    public List<Movie> ListAllMovies() => _movies;

    public string AddMovie(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        _dbContext.SaveChanges();
        updateInitialMoviesList();

        return $"{movie.Title} added to the database successfully!";
    }

    public string ModifyMovie(Movie updatedMovie)
    {
        _dbContext.Movies.Update(updatedMovie);
        _dbContext.SaveChanges();
        updateInitialMoviesList();

        return $"{updatedMovie.Title} modified in the database successfully!";
    }

    public string RemoveMovie(int id)
    {
        var movie = _dbContext.Movies.Find(id);
        if (movie != null)
        {
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            updateInitialMoviesList();

            return $"Movie: {movie.Title} is removed from the database succesfully";
        }
        return $"Movie with {id} is not found";
    }

    public bool CheckMovieExists(int? id)
    {
        return _movies.Any(m => m.Id == id);
    }

}
