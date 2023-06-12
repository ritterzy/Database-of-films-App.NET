using AutoMapper;
using EXAM.DAL.DatabaseServices;
using EXAM.DAL.Models;
using EXAM.DAL.ViewModels;
using EXAM.Helpers;
using Microsoft.AspNetCore.Mvc;



namespace EXAM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DatabaseService _databaseService;
        public MovieController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseService = new DatabaseService(databaseContext);
        }

        [Route("GetMovies")]
        [HttpGet]
        public async Task<IActionResult> GetMovies(SortState sortOrder = SortState.TitleAsc)
        {
            var movies = await _databaseService.GetMoviesAsync();
            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NameSort"] = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            ViewData["DateOfBirthSort"] = sortOrder == SortState.ReleaseDateAsc ? SortState.ReleaseDateDesc : SortState.ReleaseDateAsc;
            ViewData["CountryOfBirthSort"] = sortOrder == SortState.RatingAsc ? SortState.RatingDesc : SortState.RatingAsc;
            ViewData["AboutSort"] = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;

            movies = sortOrder switch
            {
                SortState.IdAsc => movies.OrderBy(s => s.Id),
                SortState.IdDesc => movies.OrderByDescending(s => s.Id),
                SortState.TitleAsc => movies.OrderBy(s => s.Title),
                SortState.TitleDesc => movies.OrderByDescending(s => s.Title),
                SortState.ReleaseDateAsc => movies.OrderBy(s => s.ReleaseDate),
                SortState.ReleaseDateDesc => movies.OrderByDescending(s => s.ReleaseDate),
                SortState.RatingAsc => movies.OrderBy(s => s.Rating),
                SortState.RatingDesc => movies.OrderByDescending(s => s.Rating),
                SortState.DescriptionAsc => movies.OrderBy(s => s.Description),
                SortState.DescriptionDesc => movies.OrderByDescending(s => s.Description)
            };

            return View(movies.ToList());
        }

        [Route("AddMovie")]
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            var result = await _databaseService.AddMovieAsync(movie);
            return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }
    }
}
