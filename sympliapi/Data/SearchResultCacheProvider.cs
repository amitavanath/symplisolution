using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace sympliapi.Data
{
    public class SearchResultCacheProvider<T> : ISearchResultCacheProvider<T>
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _config;

        public SearchResultCacheProvider(IDistributedCache cache, IConfiguration config)
        {
            _cache = cache;
            _config = config;
        }

        public async Task<T> GetOrCreate(string key, Func<T> createItem)
        {
            T cacheEntry;
            string cachedResult = await _cache.GetStringAsync(key);

            if (cachedResult is null)
            {
                // Key not in cache, so create data
                cacheEntry = createItem();

                TimeSpan parseConfigResult;

                var isParseSuccess = TimeSpan.TryParse(_config.GetValue<string>("CacheExpirationTimespan"), out parseConfigResult);

                var expirationTime = isParseSuccess ? parseConfigResult : new TimeSpan(0, 60, 0);

                var cacheEntryOptions = new DistributedCacheEntryOptions();
                cacheEntryOptions.SetAbsoluteExpiration(expirationTime);
                
                // Save data in cache.
                _cache.SetString(key, JsonConvert.SerializeObject(cacheEntry), cacheEntryOptions);
            }

            return JsonConvert.DeserializeObject<T>(cachedResult);
        }

    }
}
