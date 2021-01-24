using System.Collections.Generic;
using System.Threading.Tasks;
using sympliapi.Data;
using sympliapi.Entities;
using sympliapi.Models;

namespace sympliapi.Services
{
    public class SearchService : ISearchService
    {
        private readonly IServiceContext _context;

        public SearchService(IServiceContext context) => _context = context
            ?? throw new System.ArgumentNullException(nameof(context));

        
        public IEnumerable<SearchResult> GetSearchResults(SearchQueryDto searchQueryDto)
        {
            return _context.GetSearchResults();
        }
    }
}