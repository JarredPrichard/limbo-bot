using LimboBot.Model.DTO;
using LimboBot.Services.GitHub;
using LimboBot.Services.Slack;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LimboBot.Actions
{
    public abstract class LimboAction
    {
        protected LimboSettings Settings { get; set; }

        protected IGitHubService GitHub { get; set; }

        protected ISlackService Slack { get; set; }

        public LimboAction(IServiceProvider services, LimboSettings settings)
        {
            this.Settings = settings;

            this.GitHub = services.GetService<IGitHubService>();
            this.GitHub.SetCredentials(settings.GitHubUsername, settings.GitHubPersonalAccessToken);
            this.GitHub.BaseAddress = settings.GithubApiBaseUrl;

            this.Slack = services.GetService<ISlackService>();
            this.Slack.SetCredentials(settings.SlackBotApiToken);
        }

        public abstract Task Run();
    }
}
