namespace EXAM.DAL.DatabaseServices
{
    public partial class DatabaseService
    {
        private readonly DatabaseContext _context;

        public DatabaseService(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
    }
}
