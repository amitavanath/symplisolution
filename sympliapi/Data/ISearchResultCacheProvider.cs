using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sympliapi.Data
{
    public interface ISearchResultCacheProvider<T>
    {
        public Task<T> GetOrCreate(string key, Func<T> createItem);
    }
}
