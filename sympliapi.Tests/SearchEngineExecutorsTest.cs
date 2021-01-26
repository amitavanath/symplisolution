using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Newtonsoft.Json;
using sympliapi.Data;
using sympliapi.Entities;
using sympliapi.Models;
using sympliapi.SearchEngineExecutors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sympliapi.Tests
{
    public class SearchEngineExecutorsTest
    {
        [Fact]
        public async void GetGoogleSearchResults_ReturnsValue()
        {
            //Arrange
            SearchQueryDto searchQuery = new SearchQueryDto();

            var items = await GetGoogleSearchResultFromFileAsync();

            var distributedCacheMock = new Mock<IDistributedCache>();
            var cacheProviderMock = new Mock<ISearchResultCacheProvider<SearchResult>>();
            cacheProviderMock.Setup(m => m.GetOrCreate(It.IsAny<string>(), It.IsAny<Func<SearchResult>>())).Returns(Task.FromResult(items));

            var googleSearchExecutor = new GoogleSearchExecutor(distributedCacheMock.Object, cacheProviderMock.Object);

            //Act
            var result = await googleSearchExecutor.ExecuteSearchAsync(searchQuery);

            //Assert
            Assert.NotNull(result);

        }


        [Fact]
        public async void GetGoogleSearchResults_ReturnsNullValue()
        {
            //Arrange
            SearchQueryDto searchQuery = new SearchQueryDto();

            var items = await GetGoogleSearchResultFromFileAsync();

            var distributedCacheMock = new Mock<IDistributedCache>();
            var cacheProviderMock = new Mock<ISearchResultCacheProvider<SearchResult>>();

            var googleSearchExecutor = new GoogleSearchExecutor(distributedCacheMock.Object, cacheProviderMock.Object);

            //Act
            var result = await googleSearchExecutor.ExecuteSearchAsync(searchQuery);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async void GetBingSearchResults_ReturnsValue()
        {
            //Arrange
            SearchQueryDto searchQuery = new SearchQueryDto();

            var items = await GetGoogleSearchResultFromFileAsync();

            var distributedCacheMock = new Mock<IDistributedCache>();
            var cacheProviderMock = new Mock<ISearchResultCacheProvider<SearchResult>>();
            cacheProviderMock.Setup(m => m.GetOrCreate(It.IsAny<string>(), It.IsAny<Func<SearchResult>>())).Returns(Task.FromResult(items));

            var bingSearchExecutor = new BingSearchExecutor(distributedCacheMock.Object, cacheProviderMock.Object);

            //Act
            var result = await bingSearchExecutor.ExecuteSearchAsync(searchQuery);

            //Assert
            Assert.NotNull(result);

        }


        [Fact]
        public async void GetBingSearchResults_ReturnsNullValue()
        {
            //Arrange
            SearchQueryDto searchQuery = new SearchQueryDto();

            var items = await GetGoogleSearchResultFromFileAsync();

            var distributedCacheMock = new Mock<IDistributedCache>();
            var cacheProviderMock = new Mock<ISearchResultCacheProvider<SearchResult>>();

            var bingSearchExecutor = new BingSearchExecutor(distributedCacheMock.Object, cacheProviderMock.Object);

            //Act
            var result = await bingSearchExecutor.ExecuteSearchAsync(searchQuery);

            //Assert
            Assert.Null(result);

        }

        public async Task<SearchResult> GetGoogleSearchResultFromFileAsync()
        {
            var jsonData = await File.ReadAllTextAsync("GoogleSearchResult.json");
            var searchResult = JsonConvert.DeserializeObject<SearchResult>(jsonData);

            return searchResult;
        }

        public async Task<SearchResult> GetBingSearchResultFromFileAsync()
        {
            var jsonData = await File.ReadAllTextAsync("BingSearchResult.json");
            var searchResult = JsonConvert.DeserializeObject<SearchResult>(jsonData);

            return searchResult;
        }
    }
}
