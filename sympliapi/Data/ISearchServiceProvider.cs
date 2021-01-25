using System.Collections.Generic;
using System.Threading.Tasks;
using sympliapi.Entities;
using sympliapi.Models;

namespace sympliapi.Data
{
    public interface ISearchServiceProvider
    {
        public Task<IEnumerable<SearchResult>> GetSearchResultsAsync(SearchQueryDto searchQueryDto);
    }
}