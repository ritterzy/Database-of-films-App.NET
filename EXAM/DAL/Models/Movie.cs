namespace EXAM.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int ProducerId { get; set; }
        public int CountryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rating { get; set; }
        public virtual IList<Producer> Producers { get; set; } = new List<Producer>();
        public virtual Country Country { get; set; }
        public virtual IList<Genre> Genres { get; set; } = new List<Genre>();
        public virtual IList<Actor> Actors { get; set; } = new List<Actor>();
    }   
}
