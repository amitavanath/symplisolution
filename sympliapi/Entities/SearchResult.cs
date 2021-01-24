using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace sympliapi.Entities
{
    [BindRequired]
    public class SearchResult
    {
        public string SearchEngineName { get; set; }

        public string PositionResult { get; set; }
    }
}