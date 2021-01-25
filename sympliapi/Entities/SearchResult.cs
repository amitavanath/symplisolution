using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace sympliapi.Entities
{
    //[BindRequired]
    public class SearchResult
    {
        public Guid Id { get; set; }
        public string SearchEngineName { get; set; }

        public string CompanyURI { get; set; }

        public string PositionResult { get; set; }

        public string SearchTerm { get; set; }
    }
}