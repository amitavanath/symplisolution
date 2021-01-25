using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using sympliapi.Data;
using sympliapi.Entities;
using sympliapi.Models;

namespace sympliapi.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchServiceProvider _provider;
        private readonly IDistributedCache _cache;

        public SearchService(ISearchServiceProvider provider, IDistributedCache cache) 
        {
            _provider = provider;
            _cache = cache;
        }

        
        public async Task<IEnumerable<SearchResult>> GetSearchResultsAsync(SearchQueryDto searchQueryDto)
        {
            
            if(string.IsNullOrEmpty(searchQueryDto.SearchTerm) || string.IsNullOrEmpty(searchQueryDto.CompanyURI))
            {
                return new List<SearchResult>();
            }
            else
            {
                return await _provider.GetSearchResultsAsync(searchQueryDto);
            }
            
            
        }
    }
}