﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using sympliapi.Entities;
using sympliapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sympliapi.SearchEngineExecutors
{
    public class BingSearchExecutor : ISearchEngineExecutor
    {
        private readonly IDistributedCache _cache;

        public BingSearchExecutor(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<SearchResult> ExecuteSearchAsync(SearchQueryDto searchQueryDto)
        {
            var cache = await GetCachedObjectAsync(searchQueryDto);
            if ((cache is null))
            {
                var result = new SearchResult
                {
                    Id = Guid.NewGuid(),
                    SearchEngineName = "bing",
                    SearchTerm = searchQueryDto.SearchTerm,
                    PositionResult = BuildARandomPositionResult()
                };

                _cache.SetString(searchQueryDto.CompanyURI + searchQueryDto.SearchTerm + "bing", JsonConvert.SerializeObject(result));

                return result;
            }
            else
            {
                return cache;
            }

        }

        public async Task<SearchResult> GetCachedObjectAsync(SearchQueryDto searchQueryDto)
        {
            var cachedresult = await _cache.GetStringAsync(searchQueryDto.CompanyURI+searchQueryDto.SearchTerm+"bing");

            if (String.IsNullOrEmpty(cachedresult))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<SearchResult>(cachedresult);
            }
        }

        public string BuildARandomPositionResult()
        {
            Random random = new Random();
            StringBuilder positionResult = new StringBuilder();

            for (var i = 0; i <= random.Next(10); i++)
            {
                positionResult.Append(random.Next(100) + " ");
            }

            return positionResult.ToString();
        }

    }
}
