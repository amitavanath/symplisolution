using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sympliapi.Entities;
using sympliapi.Models;
using sympliapi.Services;

namespace sympliapi.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SearchResult>> GetSearchResults([FromQuery]SearchQueryDto searchQueryDto)
        {
            var results = _searchService.GetSearchResults(searchQueryDto);
            return Ok(results);
        }
    }
}