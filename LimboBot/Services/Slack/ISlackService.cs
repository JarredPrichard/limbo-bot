using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LimboBot.Services.Slack
{
    public interface ISlackService
    {
        void SetCredentials(String accessToken);
        Task<Boolean> SendMessage(String channel, String msg);
        Task<Boolean> SendMessage(SlackMessage msg);
    }
}
