using System.Collections.Generic;

namespace AwesomeApp.Models
{
    public class SearchRepoResult
    {
        public string total_count { get; set; }
        public string incomplete_results { get; set; }
        public List<Repository> items { get; set; }
    }
}
