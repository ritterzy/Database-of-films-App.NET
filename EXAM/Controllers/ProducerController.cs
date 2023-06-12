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
    public class ProducerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DatabaseService _databaseService;
        public ProducerController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseService = new DatabaseService(databaseContext);
        }

        [Route("GetProducers")]
        [HttpGet]
        public async Task<IActionResult> GetProducers(SortState sortOrder = SortState.NameAsc)
        {
            var producers = await _databaseService.GetProducersAsync();
            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["DateOfBirthSort"] = sortOrder == SortState.DateOfBirthAsc ? SortState.DateOfBirthDesc : SortState.DateOfBirthAsc;
            ViewData["CountryOfBirthSort"] = sortOrder == SortState.CountryOfBirthAsc ? SortState.CountryOfBirthDesc : SortState.CountryOfBirthAsc;
            ViewData["AboutSort"] = sortOrder == SortState.AboutAsc ? SortState.AboutDesc : SortState.AboutAsc;

            producers = sortOrder switch
            {
                SortState.IdAsc => producers.OrderBy(s => s.Id),
                SortState.IdDesc => producers.OrderByDescending(s => s.Id),
                SortState.NameAsc => producers.OrderBy(s => s.Name),
                SortState.NameDesc => producers.OrderByDescending(s => s.Name),
                SortState.DateOfBirthAsc => producers.OrderBy(s => s.DateOfBirth),
                SortState.DateOfBirthDesc => producers.OrderByDescending(s => s.DateOfBirth),
                SortState.CountryOfBirthAsc => producers.OrderBy(s => s.CountryOfBirth),
                SortState.CountryOfBirthDesc => producers.OrderByDescending(s => s.CountryOfBirth),
                SortState.AboutAsc => producers.OrderBy(s => s.About),
                SortState.AboutDesc => producers.OrderByDescending(s => s.About)
            };

            return View(producers.ToList());
        }

        [Route("AddProducer")]
        [HttpPost]
        public async Task<IActionResult> AddProducer(ProducerViewModel producerViewModel)
        {
            var producer = _mapper.Map<Producer>(producerViewModel);
            var result = await _databaseService.AddProducerAsync(producer);
            return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }
    }
}
