using Microsoft.EntityFrameworkCore;
using EXAM.DAL.Models;

namespace EXAM.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        #region non-async methods

        #region Get

        public IEnumerable<Actor> GetActors()
        {
            return _context.Actors
                .Include(e => e.Movies)
                .ToList();
        }

        public IEnumerable<Actor> GetAvtorsByName(string name)
        {
            return _context.Actors
                .Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public IEnumerable<Actor> GetActorsByName(string countryofbirth)
        {
            return _context.Actors
                .Include(e => e.Movies)
                .Where(e => e.CountryOfBirth.Contains(countryofbirth, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Actor GetActor(int id)
        {
            return _context.Actors
                .Include(e => e.Movies)
                .FirstOrDefault(e => e.Id == id);
        }

        #endregion

        #region Add
        public int AddActor(Actor actors)
        {
            _context.Actors.Add(actors);
            return _context.SaveChanges();
        }

        public int AddAcademies(IList<Actor> actors)
        {
            _context.Actors.AddRange(actors);
            return _context.SaveChanges();
        }


        #endregion

        #region Update

        public int UpdateActor(Actor actor)
        {
            _context.Actors.Update(actor);
            return _context.SaveChanges();
        }

        public int UpdateStudent(IList<Actor> actors)
        {
            _context.Actors.UpdateRange(actors);
            return _context.SaveChanges();
        }

        #endregion

        #region Remove 

        public int RemoveActor(Actor actor)
        {
            _context.Actors.Remove(actor);
            return _context.SaveChanges();
        }

        public int RemoveActorById(int id)
        {
            var resActor = _context.Actors.FirstOrDefault(e => e.Id == id);
            if (resActor is null)
            {
                return default;
            }

            _context.Actors.Remove(resActor);
            return _context.SaveChanges();
        }




        #endregion

        #endregion

        #region async methods

        #region Get

        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return await _context.Actors
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public async Task<IEnumerable<Actor>> GetActorsByNameAsync(string name)
        {
            return await _context.Actors
                .Include(e => e.Movies)
                .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<IEnumerable<Actor>> GetStudentsByCountryOfBirthAsync(string countryofbirth)
        {
            return await _context.Actors
                .Include(e => e.Movies)
                .Where(e => e.CountryOfBirth.Contains(countryofbirth, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Actor> GetActorAsync(int id)
        {
            return await _context.Actors
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        #endregion

        #region Add

        public async Task<int> AddActorAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task<int> UpdateActorAsync(Actor actor)
        {
            _context.Actors.Update(actor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateActrosAsync(IList<Actor> actors)
        {
            _context.Actors.UpdateRange(actors);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public async Task<int> RemoveActorAsync(Actor actor)
        {
            _context.Actors.Remove(actor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAcademyByIdAsync(int id)
        {
            var resActor = await _context.Actors.FirstOrDefaultAsync(e => e.Id == id);
            if (resActor is null)
            {
                return default;
            }

            _context.Actors.Remove(resActor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveActorsAsync(IList<Actor> actors)
        {
            _context.Actors.RemoveRange(actors);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #endregion
    }
}
