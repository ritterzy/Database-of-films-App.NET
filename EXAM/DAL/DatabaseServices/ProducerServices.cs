using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Producer> GetProducer()
        {
            return _context.Producers
                .Include(e => e.Movies)
                .ToList();
        }

        public IEnumerable<Producer> GetProducersByName(string name)
        {
            return _context.Producers.Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Producer GetProducer(int id)
        {
            return _context.Producers
                .Include(e => e.Movies)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddProducer(Producer producers)
        {
            _context.Producers.Add(producers);
            return _context.SaveChanges();
        }

        public int AddProducers(IList<Producer> producers)
        {
            _context.Producers.AddRange(producers);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public async Task<int> UpdateProducerAsync(Producer producer)
        {
            _context.Producers.Update(producer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateProducersAsync(IList<Producer> producers)
        {
            _context.Producers.UpdateRange(producers);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove 

        public int RemoveProducer(Producer producer)
        {
            _context.Producers.Remove(producer);
            return _context.SaveChanges();
        }

        public int RemoveProducerById(int id)
        {
            var resProducer = _context.Producers.FirstOrDefault(e => e.Id == id);
            if (resProducer is null)
            {
                return default;
            }

            _context.Producers.Remove(resProducer);
            return _context.SaveChanges();
        }

        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Producer>> GetProducersAsync()
        {
            return await _context.Producers
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public async Task<IEnumerable<Producer>> GetProducersByNameAsync(string name)
        {
            return await _context.Producers
                .Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<IEnumerable<Producer>> GetProducersByCountryOfBirthAsync(string countryofbirth)
        {
            return await _context.Producers
                .Include(e => e.Movies)
                .Where(e => e.CountryOfBirth.Contains(countryofbirth, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Producer> GetProducerAsync(int id)
        {
            return await _context.Producers.Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddProducerAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update

        public int UpdateProducer(Producer producer)
        {
            _context.Producers.Update(producer);
            return _context.SaveChanges();
        }

        public int UpdateProducer(IList<Producer> producers)
        {
            _context.Producers.UpdateRange(producers);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveProducerAsync(Producer producer)
        {
            _context.Producers.Remove(producer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveProducerByIdAsync(int id)
        {
            var resProducer = await _context.Producers.FirstOrDefaultAsync(e => e.Id == id);
            if (resProducer is null)
            {
                return default;
            }

            _context.Producers.Remove(resProducer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveProducersAsync(IList<Producer> producers)
        {
            _context.Producers.RemoveRange(producers);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
