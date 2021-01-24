using sympliapi.Entities;
using sympliapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sympliapi.SearchEngineExecutors
{
    public interface ISearchEngineExecutor
    {
        public SearchResult ExecuteSearch(SearchQueryDto searchQueryDto);
    }
}
