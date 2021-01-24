using System.Collections.Generic;
using sympliapi.Entities;
using sympliapi.Models;

namespace sympliapi.Services
{
    public interface ISearchService
    {
        public IEnumerable<SearchResult> GetSearchResults(SearchQueryDto searchQueryDto);
    }
}