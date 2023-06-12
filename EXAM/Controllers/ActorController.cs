
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
    public class ActorController: Controller
    {
        private readonly IMapper _mapper;
        private readonly DatabaseService _databaseService;
        public ActorController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseService = new DatabaseService(databaseContext);
        }

        [Route("GetActors")]
        [HttpGet]
        public async Task<IActionResult> GetActors(SortState sortOrder = SortState.NameAsc)
        {
            var actors = await _databaseService.GetActorsAsync();
            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["DateOfBirthSort"] = sortOrder == SortState.DateOfBirthAsc ? SortState.DateOfBirthDesc : SortState.DateOfBirthAsc;
            ViewData["CountryOfBirthSort"] = sortOrder == SortState.CountryOfBirthAsc ? SortState.CountryOfBirthDesc : SortState.CountryOfBirthAsc;
            ViewData["AboutSort"] = sortOrder == SortState.AboutAsc ? SortState.AboutDesc : SortState.AboutAsc;

            actors = sortOrder switch
            {
                SortState.IdAsc => actors.OrderBy(s => s.Id),
                SortState.IdDesc => actors.OrderByDescending(s => s.Id),
                SortState.NameAsc => actors.OrderBy(s => s.Name),
                SortState.NameDesc => actors.OrderByDescending(s => s.Name),
                SortState.DateOfBirthAsc => actors.OrderBy(s => s.DateOfBirth),
                SortState.DateOfBirthDesc => actors.OrderByDescending(s => s.DateOfBirth),
                SortState.CountryOfBirthAsc => actors.OrderBy(s => s.CountryOfBirth),
                SortState.CountryOfBirthDesc => actors.OrderByDescending(s => s.CountryOfBirth),
                SortState.AboutAsc => actors.OrderBy(s => s.About),
                SortState.AboutDesc => actors.OrderByDescending(s => s.About)
            };

            return View(actors.ToList());
        }

        [Route("AddActor")]
        [HttpPost]
        public async Task<IActionResult> AddActor(ActorViewModel actorViewModel)
        {
            var actor = _mapper.Map<Actor>(actorViewModel);
            var result = await _databaseService.AddActorAsync(actor);
            return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }
    }
}
