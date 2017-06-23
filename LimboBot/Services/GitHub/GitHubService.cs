using LimboBot.Model.DTO;
using LimboBot.Util;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LimboBot.Services.GitHub
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public String Username { get; internal set; }
        public String PersonalAccessToken { get; internal set; }

        private String _baseAddress = "https://api.github.com";
        public String BaseAddress
        {
            get { return this._baseAddress; }
            set
            {
                this._baseAddress = value;
                this.httpClient.BaseAddress = new Uri(value);
            }
        }

        public GitHubService() : this("", "")
        {
        }

        public GitHubService(String username, String personalAccessToken)
        {
            this.Username = username;
            this.PersonalAccessToken = personalAccessToken;

            this.initializeHttpClient();
        }

        public void SetBaseAddress(String baseAddress)
        {
            this.BaseAddress = baseAddress;
        }

        public void SetCredentials(String username, String personalAccessToken)
        {
            this.Username = username;
            this.PersonalAccessToken = personalAccessToken;

            this.initializeHttpClient();
        }

        private void initializeHttpClient()
        {
            Boolean hasCredentials = !String.IsNullOrWhiteSpace(this.Username) && !String.IsNullOrWhiteSpace(this.PersonalAccessToken);

            //Only add auth if credentials are filled out... otherwise, will assume public access
            this.httpClient.DefaultRequestHeaders.Authorization = !hasCredentials ? null : HttpUtility.BuildBasicHttpAuthHeader(this.Username, this.PersonalAccessToken);

            this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Limbo", "v1"));
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.mercy-preview+json"));
        }

        public async Task<GitHubIssuesSearchResult> SearchIssues(String query)
        {
            QueryBuilder b = new QueryBuilder();
            b.Add("q", query);

            String rawJson = await this.httpClient.GetStringAsync("/search/issues" + b.ToString());

            return JsonConvert.DeserializeObject<GitHubIssuesSearchResult>(rawJson);
        }

        void IDisposable.Dispose()
        {
            this.httpClient.Dispose();
        }


    }
}
