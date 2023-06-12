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
    public class CountryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DatabaseService _databaseService;
        public CountryController(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseService = new DatabaseService(databaseContext);
        }

        [Route("GetCountries")]
        [HttpGet]
        public async Task<IActionResult> GetCountries(SortState sortOrder = SortState.NameAsc)
        {
            var countries = await _databaseService.GetCountriesAsync();
            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;

            countries = sortOrder switch
            {
                SortState.IdAsc => countries.OrderBy(s => s.Id),
                SortState.IdDesc => countries.OrderByDescending(s => s.Id),
                SortState.NameAsc => countries.OrderBy(s => s.Name),
                SortState.NameDesc => countries.OrderByDescending(s => s.Name)
            };

            return View(countries.ToList());
        }

        [Route("AddCountry")]
        [HttpPost]
        public async Task<IActionResult> AddCountry(CountryViewModel countryViewModel)
        {
            var country = _mapper.Map<Genre>(countryViewModel);
            var result = await _databaseService.AddGenreAsync(country);
            return result > 0 ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }
    }
}
