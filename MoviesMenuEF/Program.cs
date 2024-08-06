using MoviesMenuEFCore.Contexts;
using MoviesMenuEFCore.Services;

namespace MoviesMenuEFCore;

class Program
{
    public static List<Option> MenuOptions = [];
    public static MovieService movieService = new();
    public static MovieConsoleService movieConsoleService = new(movieService);

    static void Main(string[] args)
    {

        using (MyBootcampDbContext context = new())
        {
            movieService.SetDbContext(context);

            // Movie Menu Options
            MenuOptions = new List<Option>
            {
                new Option("List all available movies.", movieConsoleService.ListAllMovies),
                new Option("Add a new movie to the list.", movieConsoleService.AddMovie),
                new Option("Modify an existing movie.", movieConsoleService.ModifyMovie),
                new Option("Remove a movie from the list", movieConsoleService.RemoveMovie),
                new Option("Exit the program.", () => Environment.Exit(0))
            };

            // default is List all available _movies
            int index = 0;

            // Write the menu out
            movieConsoleService.DisplayMenu(MenuOptions, index);
            movieConsoleService.HandleMenuSelection(MenuOptions);

            Console.ReadKey();
        }
    }
}
