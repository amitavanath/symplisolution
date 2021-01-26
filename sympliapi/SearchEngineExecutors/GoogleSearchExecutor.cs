using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using sympliapi.Data;
using sympliapi.Entities;
using sympliapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sympliapi.SearchEngineExecutors
{
    public class GoogleSearchExecutor : ISearchEngineExecutor
    {
        private readonly IDistributedCache _cache;

        private readonly ISearchResultCacheProvider<SearchResult> _searchResultCacheProvider;

        public GoogleSearchExecutor(IDistributedCache cache, ISearchResultCacheProvider<SearchResult> searchResultCacheProvider)
        {
            _cache = cache;
            _searchResultCacheProvider = searchResultCacheProvider;
        }

        public async Task<SearchResult> ExecuteSearchAsync(SearchQueryDto searchQueryDto)
        {
            var cacheKey = searchQueryDto.CompanyURI + searchQueryDto.SearchTerm + SearchEngineNames.Google;
            var searchResult = await _searchResultCacheProvider.GetOrCreate(cacheKey, () => GetSearchData(searchQueryDto));

            return searchResult;
        }

        private SearchResult GetSearchData(SearchQueryDto searchQueryDto)
        {
            var result = new SearchResult
            {
                Id = Guid.NewGuid(),
                SearchEngineName = SearchEngineNames.Google,
                SearchTerm = searchQueryDto.SearchTerm,
                PositionResult = BuildARandomPositionResult()
            };

            return result;
        }

        

        public string BuildARandomPositionResult()
        {
            Random random = new Random();
            StringBuilder positionResult = new StringBuilder();

            for (var i = 0; i <= random.Next(10); i++)
            {
                positionResult.Append(random.Next(100) + " ");
            }

            return positionResult.ToString().Trim();
        }

    }
}
