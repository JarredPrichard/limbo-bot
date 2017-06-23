using Newtonsoft.Json;
using System;

namespace LimboBot.Model.DTO
{
    public class GitHubIssue
    {
        public String Url { get; set; }

        [JsonProperty(PropertyName = "repository_url")]
        public String RepositoryUrl { get; set; }

        [JsonProperty(PropertyName = "labels_url")]
        public String LabelsUrl { get; set; }

        [JsonProperty(PropertyName = "comments_url")]
        public String CommentsUrl { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public String HtmlUrl { get; set; }

        public double Id { get; set; }
        public double Number { get; set; }
        public String Title { get; set; }
        public String State { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "closed_at")]
        public DateTime? ClosedAt { get; set; }
        public String Body { get; set; }
        public double Score { get; set; }

        public GitHubUser User { get; set; }
    }
}
