using MediatR;
using sympliapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sympliapi.Queries
{
    public class GetSearchResultsQuery : IRequest<IEnumerable<SearchResultDto>>
    {
        public SearchQueryDto _searchQueryDto;

        public GetSearchResultsQuery(SearchQueryDto searchQueryDto)
        {
            _searchQueryDto = searchQueryDto;
        }
    }
}
