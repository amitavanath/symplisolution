using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sympliapi.Entities;
using sympliapi.Models;
using sympliapi.Queries;
using sympliapi.Services;

namespace sympliapi.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchResultDto>>> GetSearchResults([FromQuery]SearchQueryDto searchQueryDto)
        {
            var query = new GetSearchResultsQuery(searchQueryDto);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}