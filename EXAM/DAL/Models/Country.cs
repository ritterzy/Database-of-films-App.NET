namespace EXAM.DAL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Movie> Movies { get; set;} = new List<Movie>();
    }
}
