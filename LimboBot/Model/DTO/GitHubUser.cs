using Newtonsoft.Json;
using System;

namespace LimboBot.Model.DTO
{
    public class GitHubUser
    {
        public String Login { get; set; }
        public double id { get; set; }        
        public String Url { get; set; }        
        public String Type { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public String AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "gravatar_id")]
        public String GravatarId { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public String HtmlUrl { get; set; }

        [JsonProperty(PropertyName = "site_admin")]
        public Boolean SiteAdmin { get; set; }
    }
}
