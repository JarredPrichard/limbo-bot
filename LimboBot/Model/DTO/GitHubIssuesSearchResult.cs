using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LimboBot.Model.DTO
{
    public class GitHubIssuesSearchResult
    {
        [JsonProperty(PropertyName = "total_count")]
        public double TotalCount { get; set; }

        [JsonProperty(PropertyName = "incomplete_results")]
        public Boolean IncompleteResults { get; set; }

        public List<GitHubIssue> Items { get; set; }
    }
}
