namespace EXAM.DAL.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string About { get; set; }
        public virtual IList<Movie> Movies { get; set; } = new List<Movie>();
    }
}
