using AutoMapper;

namespace sympliapi.Profiles
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<Entities.SearchResult, Models.SearchResultDto>();
        }
    }
}
