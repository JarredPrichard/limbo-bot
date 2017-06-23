using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimboBot.Services.Slack
{
    public class SlackMessage
    {
        public String Text { get; set; }
        public String Channel { get; set; }
        public String Username { get; set; }
        public String IconEmoji { get; set; }
        public Boolean SendAsUser { get; set; } = true;
        public List<SlackMessageAttachment> Attachments { get; set; } = new List<SlackMessageAttachment>();

        public SlackMessage(String message, String channel)
        {
            this.Text = message;
            this.Channel = channel;
        }

        public Dictionary<String, String> ToDictionary()
        {
            var data = new Dictionary<string, string>() {
                { "text", this.Text },
                { "channel", this.Channel },
                { "username", this.Username},
                { "icon_emoji", this.IconEmoji },
                { "as_user", this.SendAsUser ? "true" : "false" }
            };

            if (this.Attachments.Count > 0)
            {
                String json = JsonConvert.SerializeObject(this.Attachments);
                data.Add("attachments", json);
            }

            return data;
        }
    }
}
