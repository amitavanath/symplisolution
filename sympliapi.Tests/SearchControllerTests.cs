using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using sympliapi.Controllers;
using sympliapi.Models;
using sympliapi.Queries;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace sympliapi.Tests
{
    public class SearchControllerTests
    {
        [Fact]
        public async void GetSearchResultsController_ReturnsOkValue()
        {
            //Arrange
            var httpContext = new DefaultHttpContext();

            SearchQueryDto searchQueryDto = new SearchQueryDto();
            GetSearchResultsQuery query = new GetSearchResultsQuery(searchQueryDto);

            var items = await GetSearchResultsDtoFromFileAsync();

            var mediator = new Mock<IMediator>();
            mediator.Setup(m => m.Send(It.IsAny<GetSearchResultsQuery>(), new System.Threading.CancellationToken())).Returns(Task.FromResult(items));

            var controller = new SearchController(mediator.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            //ACT 
            var result = await controller.GetSearchResults(searchQueryDto);

            //ASSERT
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsAssignableFrom<IActionResult>(result.Result);
        }

        public async Task<IEnumerable<SearchResultDto>> GetSearchResultsDtoFromFileAsync()
        {
            var jsonData = await File.ReadAllTextAsync("SearchResultsDto.json");

            List<SearchResultDto> searchResults = new List<SearchResultDto>();
            searchResults = JsonConvert.DeserializeObject<List<SearchResultDto>>(jsonData);

            return searchResults;
        }

        
    }
}
