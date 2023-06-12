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
    public class GenreController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DatabaseService _databaseService;
        public GenreController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseService = new DatabaseService(databaseContext);
        }

        [Route("GetGenres")]
        [HttpGet]
        public async Task<IActionResult> GetGenres(SortState sortOrder = SortState.NameAsc)
        {
            var genres = await _databaseService.GetGenresAsync();
            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;

            genres = sortOrder switch
            {
                SortState.IdAsc => genres.OrderBy(s => s.Id),
                SortState.IdDesc => genres.OrderByDescending(s => s.Id),
                SortState.NameAsc => genres.OrderBy(s => s.Name),
                SortState.NameDesc => genres.OrderByDescending(s => s.Name)
            };

            return View(genres.ToList());
        }

        [Route("AddGenre")]
        [HttpPost]
        public async Task<IActionResult> AddGenre(GenreViewModel genreViewModel)
        {
            var genre = _mapper.Map<Genre>(genreViewModel);
            var result = await _databaseService.AddGenreAsync(genre);
            return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }
    }
}
