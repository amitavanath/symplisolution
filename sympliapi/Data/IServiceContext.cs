using System.Collections.Generic;
using sympliapi.Entities;

namespace sympliapi.Data
{
    public interface IServiceContext
    {
         public IEnumerable<SearchResult> GetSearchResults();
    }
}