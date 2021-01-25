using System.Collections.Generic;
using System.Threading.Tasks;
using sympliapi.Entities;
using sympliapi.Models;

namespace sympliapi.Services
{
    public interface ISearchService
    {
        public Task<IEnumerable<SearchResult>> GetSearchResultsAsync(SearchQueryDto searchQueryDto);
    }
}