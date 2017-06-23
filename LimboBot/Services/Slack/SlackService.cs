using LimboBot.Util;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LimboBot.Services.Slack
{
    public class SlackService : ISlackService
    {
        private readonly HttpClient httpClient = new HttpClient();
        private String accessToken;

        public SlackService() : this("") { }

        public SlackService(String accessToken) :
            this("https://slack.com/api/", accessToken)
        { }

        public SlackService(String baseAddress, String accessToken)
        {
            this.initializeHttpClient(baseAddress, accessToken);
            this.accessToken = accessToken;
        }

        public void SetCredentials(String accessToken)
        {
            this.accessToken = accessToken;
        }

        private void initializeHttpClient(String baseAddress, String accessToken)
        {
            this.httpClient.BaseAddress = new Uri(baseAddress);

            this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Limbo", "v1"));
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Boolean> SendMessage(String channel, String msg)
        {

            HttpContent postData = new FormUrlEncodedContent(new Dictionary<String, String>() {
                { "token", this.accessToken },
                { "text", msg},
                { "channel", channel}
            });

            HttpResponseMessage response = await this.httpClient.PostAsync("chat.postMessage", postData);
            String json = await response.Content.ReadAsStringAsync();

            return true;
        }

        public async Task<Boolean> SendMessage(SlackMessage msg)
        {
            var postData = msg.ToDictionary();
            postData.Add("token", this.accessToken);

            HttpContent postContent = new FormUrlEncodedContent(postData);

            HttpResponseMessage response = await this.httpClient.PostAsync("chat.postMessage", postContent);
            String json = await response.Content.ReadAsStringAsync();

            return true;
        }

    }
}
