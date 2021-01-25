using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sympliapi.Models
{
    public class SearchResultDto
    {
        public Guid Id { get; set; }
        public string SearchEngineName { get; set; }

        //public string CompanyURI { get; set; }

        public string PositionResult { get; set; }

        //public string SearchTerm { get; set; }
    }
}
