namespace EXAM.DAL.Models
{
    public class Genre
    {
        public int Id { get; set; } 
        public int MovieId { get; set; }
        public string Name { get; set; }
        public virtual IList<Movie> Movies { get; set; } = new List<Movie>();
    }
}
