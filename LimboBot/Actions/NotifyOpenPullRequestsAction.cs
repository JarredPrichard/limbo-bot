using System;
using System.Collections.Generic;
using System.Text;
using LimboBot.Model.DTO;
using System.Threading.Tasks;
using LimboBot.Services.Slack;
using LimboBot.Util;

namespace LimboBot.Actions
{
    class NotifyOpenPullRequestsAction : LimboAction
    {
        public Random Random { get; set; } = new Random();

        public NotifyOpenPullRequestsAction(IServiceProvider services, LimboSettings settings) : base(services, settings)
        {
        }

        public override async Task Run()
        {
            var openPullRequests = await this.GitHub.SearchIssues(Settings.PullRequestQueryString);
            SlackMessage msg = this.BuildSlackMessage();

            Boolean hasWhitelist = this.Settings.UsersWhitelist.Count > 0;

            //TODO: Add pagination support
            foreach (GitHubIssue issue in openPullRequests.Items)
            {
                if (!hasWhitelist || this.Settings.UsersWhitelist.Contains(issue.User.Login))
                {
                    msg.Attachments.Add(this.BuildAttachment(issue));
                }
            }

            if (msg.Attachments.Count >= 0) {
                await this.Slack.SendMessage(msg);
            }
        }

        private SlackMessage BuildSlackMessage()
        {
            int commentIndex = this.Random.Next(0, this.Settings.OpenIssuesComments.Count);
            String comment = this.Settings.OpenIssuesComments.Count > 0 ? Settings.OpenIssuesComments[commentIndex] : "You have open pull requests!";

            SlackMessage msg = new SlackMessage(comment, this.Settings.SlackChannel)
            {
                SendAsUser = true,
                Username = "LimboBot"
            };

            return msg;
        }

        private SlackMessageAttachment BuildAttachment(GitHubIssue issue)
        {
            return new SlackMessageAttachment()
            {
                Fallback = String.Format("Pull Request: '{0}' created on {1}", issue.Title, issue.CreatedAt),
                Footer = issue.User.Login,
                Title = issue.Title,
                Timestamp = issue.CreatedAt,
                FooterIcon = issue.User.AvatarUrl,
                TitleLink = issue.HtmlUrl,
                //Text = issue.Body.Length < 30 ? issue.Body : issue.Body.Substring(0, 30),
                Color = new SimpleColor("#27ae60")
            };
        }
    }
}
