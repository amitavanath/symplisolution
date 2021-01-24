using System.Collections.Generic;
using System.Threading.Tasks;
using sympliapi.Entities;

namespace sympliapi.Data
{
    public class SearchServiceContext : IServiceContext
    {
        public IEnumerable<SearchResult> GetSearchResults()
        { 
            List<SearchResult> searchResults = new List<SearchResult>();

            searchResults.Add( new SearchResult{
                SearchEngineName = "Google",
                PositionResult = "1, 2, 7, 10"
            });

            searchResults.Add( new SearchResult{
                SearchEngineName = "Bing",
                PositionResult = "5, 8, 10, 12"
            });

            return searchResults;
            
        }
    }
}