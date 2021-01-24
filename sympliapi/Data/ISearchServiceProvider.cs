using System.Collections.Generic;
using sympliapi.Entities;
using sympliapi.Models;

namespace sympliapi.Data
{
    public interface ISearchServiceProvider
    {
         public IEnumerable<SearchResult> GetSearchResults(SearchQueryDto searchQueryDto);
    }
}