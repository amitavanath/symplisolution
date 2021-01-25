using AutoMapper;
using MediatR;
using sympliapi.Entities;
using sympliapi.Models;
using sympliapi.Queries;
using sympliapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace sympliapi.Handlers
{
    public class GetSearchResultsHandler : IRequestHandler<GetSearchResultsQuery, IEnumerable<SearchResultDto>>
    {
        private readonly ISearchService _searchService;

        private readonly IMapper _mapper;

        public GetSearchResultsHandler(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchResultDto>> Handle(GetSearchResultsQuery request, CancellationToken cancellationToken)
        {
            var searchResults = await _searchService.GetSearchResultsAsync(request._searchQueryDto);
            return _mapper.Map<IEnumerable<SearchResult>, IEnumerable<SearchResultDto>>(searchResults);
        }
    }
}
