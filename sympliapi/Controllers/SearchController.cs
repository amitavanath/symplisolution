using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sympliapi.Models;
using sympliapi.Services;

namespace sympliapi.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchRepository;

        public SearchController(ISearchService searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpGet]
        public IActionResult GetSearchResults(SearchQueryDto searchQueryDto)
        {
            return Ok(_searchRepository.GetSearchResults(searchQueryDto));
        }
    }
}