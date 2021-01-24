using System.Collections.Generic;
using System.Threading.Tasks;
using sympliapi.Entities;
using sympliapi.Models;
using sympliapi.SearchEngineExecutors;

namespace sympliapi.Data
{
    public class SearchServiceProvider : ISearchServiceProvider
    {
        private readonly IEnumerable<ISearchEngineExecutor> _executors;

        public SearchServiceProvider(IEnumerable<ISearchEngineExecutor> executors) => _executors = executors;

        public IEnumerable<SearchResult> GetSearchResults(SearchQueryDto searchQueryDto)
        {
            List<SearchResult> results = new List<SearchResult>();

            foreach (var executor in _executors)
            {
                var result = executor.ExecuteSearch(searchQueryDto);
                results.Add(result);
            }

            return results;

        }
    }
}