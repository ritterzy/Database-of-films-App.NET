using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Genre> GetGenre()
        {
            return _context.Genres
                .Include(e => e.Movies)
                .ToList();
        }

        public IEnumerable<Genre> GetGenresByName(string name)
        {
            return _context.Genres.Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Genre GetGenre(int id)
        {
            return _context.Genres
                .Include(e => e.Movies)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddGenre(Genre genres)
        {
            _context.Genres.Add(genres);
            return _context.SaveChanges();
        }

        public int AddGenres(IList<Genre> genres)
        {
            _context.Genres.AddRange(genres);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateGenre(Genre genre)
        {
            _context.Genres.Update(genre);
            return _context.SaveChanges();
        }

        public int UpdateGenre(IList<Genre> genres)
        {
            _context.Genres.UpdateRange(genres);
            return _context.SaveChanges();
        }


        #endregion

        #region Remove 

        public int RemoveGenre(Genre genre)
        {
            _context.Genres.Remove(genre);
            return _context.SaveChanges();
        }

        public int RemoveGenreById(int id)
        {
            var resGenre = _context.Genres.FirstOrDefault(e => e.Id == id);
            if (resGenre is null)
            {
                return default;
            }

            _context.Genres.Remove(resGenre);
            return _context.SaveChanges();
        }

        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresByNameAsync(string name)
        {
            return await _context.Genres
                .Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Genre> GetGenreAsync(int id)
        {
            return await _context.Genres
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task<int> UpdateGenreAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateGenresAsync(IList<Genre> genres)
        {
            _context.Genres.UpdateRange(genres);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveGenreAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveGenreByIdAsync(int id)
        {
            var resGenre = await _context.Genres.FirstOrDefaultAsync(e => e.Id == id);
            if (resGenre is null)
            {
                return default;
            }

            _context.Genres.Remove(resGenre);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveGenresAsync(IList<Genre> genres)
        {
            _context.Genres.RemoveRange(genres);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
