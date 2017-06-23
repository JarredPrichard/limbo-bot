using System;
using System.Collections.Generic;

namespace LimboBot.Model.DTO
{
    public class LimboSettings
    {
        public String PullRequestQueryString { get; set; }
        public String GitHubUsername { get; set; }
        public String GitHubPersonalAccessToken { get; set; }
        public String GithubApiBaseUrl { get; set; } = "https://api.github.com";
        public List<String> UsersWhitelist { get; set; } = new List<String>();
        public List<String> OpenIssuesComments { get; set; } = new List<String>();
        public String SlackBotApiToken { get; set; }
        public String SlackChannel { get; set; }
    }
}
