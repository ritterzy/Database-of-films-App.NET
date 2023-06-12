using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Country> GetCountry()
        {
            return _context.Countries
                .Include(e => e.Movies)
                .ToList();
        }

        public IEnumerable<Country> GetCountriesByName(string name)
        {
            return _context.Countries.Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries
                .Include(e => e.Movies)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddCountry(Country countries)
        {
            _context.Countries.Add(countries);
            return _context.SaveChanges();
        }

        public int AddCountries(IList<Country> countries)
        {
            _context.Countries.AddRange(countries);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            return _context.SaveChanges();
        }

        public int UpdateCountry(IList<Country> countries)
        {
            _context.Countries.UpdateRange(countries);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove 

        public int RemoveCountry(Country country)
        {
            _context.Countries.Remove(country);
            return _context.SaveChanges();
        }

        public int RemoveCountryById(int id)
        {
            var resCountry = _context.Countries.FirstOrDefault(e => e.Id == id);
            if (resCountry is null)
            {
                return default;
            }

            _context.Countries.Remove(resCountry);
            return _context.SaveChanges();
        }

        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetCountriesByNameAsync(string name)
        {
            return await _context.Countries
                .Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Country> GetCountryAsync(int id)
        {
            return await _context.Countries
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddCountryAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task<int> UpdateCountryAsync(Country country)
        {
            _context.Countries.Update(country);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCountriesAsync(IList<Country> countries)
        {
            _context.Countries.UpdateRange(countries);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveCountryAsync(Country country)
        {
            _context.Countries.Remove(country);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveCountryByIdAsync(int id)
        {
            var resCountry = await _context.Countries.FirstOrDefaultAsync(e => e.Id == id);
            if (resCountry is null)
            {
                return default;
            }

            _context.Countries.Remove(resCountry);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveCountriesAsync(IList<Country> countries)
        {
            _context.Countries.RemoveRange(countries);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
