using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace LimboBot.Util
{
    class HttpUtility
    {
        public static AuthenticationHeaderValue BuildBasicHttpAuthHeader(String username, String password)
        {
            byte[] valBytes = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
            String headerVal = Convert.ToBase64String(valBytes);
            return new AuthenticationHeaderValue("Basic", headerVal);
        }
    }
}
