using AutoMapper;
using Moq;
using Newtonsoft.Json;
using sympliapi.Entities;
using sympliapi.Handlers;
using sympliapi.Models;
using sympliapi.Profiles;
using sympliapi.Queries;
using sympliapi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sympliapi.Tests
{
    public class SearchHandlerTests
    {
        private static IMapper _mapper;

        public SearchHandlerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new SearchProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async void GetSearchResultsHandler_ReturnsNotNullResult()
        {
            //Arrange
            var searchServiceMock = new Mock<ISearchService>();
            searchServiceMock.Setup(a => a.GetSearchResultsAsync(It.IsAny<SearchQueryDto>())).Returns(GetSearchResultsFromFileAsync()).Verifiable();

            GetSearchResultsHandler handler = new GetSearchResultsHandler(searchServiceMock.Object, _mapper);
            
            SearchQueryDto searchQueryDto = new SearchQueryDto();
            GetSearchResultsQuery query = new GetSearchResultsQuery(searchQueryDto);
            
            //Act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetSearchResultsHandler_ReturnsNoResult()
        {
            //Arrange
            var searchServiceMock = new Mock<ISearchService>();

            GetSearchResultsHandler handler = new GetSearchResultsHandler(searchServiceMock.Object, _mapper);

            SearchQueryDto searchQueryDto = new SearchQueryDto();
            GetSearchResultsQuery query = new GetSearchResultsQuery(searchQueryDto);

            //Act
            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            //Assert
            Assert.Empty(result);
        }


        public async Task<IEnumerable<SearchResult>> GetSearchResultsFromFileAsync()
        {
            var jsonData = await File.ReadAllTextAsync("SearchResults.json");

            List<SearchResult> searchResults = new List<SearchResult>();
            searchResults = JsonConvert.DeserializeObject<List<SearchResult>>(jsonData);

            return searchResults;
        }
    }
}
