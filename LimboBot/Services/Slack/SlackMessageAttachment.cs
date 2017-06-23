using LimboBot.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimboBot.Services.Slack
{
    public class SlackMessageAttachment
    {
        [JsonProperty("fallback")]
        public String Fallback { get; set; }

        [JsonProperty("color")]
        public SimpleColor Color { get; set; }

        [JsonProperty("pretext")]
        public String Pretext { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("title_link")]
        public String TitleLink { get; set; }

        [JsonProperty("text")]
        public String Text { get; set; }

        [JsonProperty("footer")]
        public String Footer { get; set; }

        [JsonProperty("footer_icon")]
        public String FooterIcon { get; set; }

        [JsonProperty("ts")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Timestamp { get; set; }        
    }
}
