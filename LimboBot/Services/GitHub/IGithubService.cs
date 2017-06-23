using LimboBot.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LimboBot.Services.GitHub
{
    public interface IGitHubService : IDisposable
    {
        void SetCredentials(String username, String personalAccessToken);        
        Task<GitHubIssuesSearchResult> SearchIssues(String query);

        String BaseAddress { get; set; }
    }
}
