using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Movie> GetMovie()
        {
            return _context.Movies
                .Include(e => e.Producers)
                .Include(e => e.Genres)
                .Include(e => e.Actors) 
                .Include(e => e.Country)
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesByName(string title)
        {
            return _context.Movies.Include(e => e.Producers).Include(e => e.Genres).Include(e => e.Actors).Include(e => e.Country)
                .Where(e => e.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies
                .Include(e => e.Producers).Include(e => e.Genres).Include(e => e.Actors).Include(e => e.Country)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddMovie(Movie movies)
        {
            _context.Movies.Add(movies);
            return _context.SaveChanges();
        }

        public int AddMovies(IList<Movie> movies)
        {
            _context.Movies.AddRange(movies);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            return _context.SaveChanges();
        }

        public int UpdateMovie(IList<Movie> movies)
        {
            _context.Movies.UpdateRange(movies);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove 

        public int RemoveMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            return _context.SaveChanges();
        }

        public int RemoveMovieById(int id)
        {
            var resMovie = _context.Movies.FirstOrDefault(e => e.Id == id);
            if (resMovie is null)
            {
                return default;
            }

            _context.Movies.Remove(resMovie);
            return _context.SaveChanges();
        }

        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies
                .Include(e => e.Actors).Include(e => e.Producers).Include(e => e.Genres).Include(e => e.Country)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByTitleAsync(string title)
        {
            return await _context.Movies
                .Include(e => e.Actors).Include(e => e.Genres).Include(e => e.Producers).Include(e => e.Country)
                .Where(e => e.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _context.Movies
                .Include(e => e.Actors)
                .Include(e => e.Genres)
                .Include(e => e.Country)
                .Include(e => e.Producers)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update

        public async Task<int> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateMoviesAsync(IList<Movie> movies)
        {
            _context.Movies.UpdateRange(movies);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region Remove
        public async Task<int> RemoveMovieAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveMovieByIdAsync(int id)
        {
            var resMovie = await _context.Movies.FirstOrDefaultAsync(e => e.Id == id);
            if (resMovie is null)
            {
                return default;
            }

            _context.Movies.Remove(resMovie);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveMoviesAsync(IList<Movie> movies)
        {
            _context.Movies.RemoveRange(movies);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
