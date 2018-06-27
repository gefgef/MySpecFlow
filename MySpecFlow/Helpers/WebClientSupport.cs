using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MySpecFlow.Helpers
{
    public static class WebClientSupport
    {
        private static WebClient client = new WebClient();

        public static string getPagesContent(string Url)
        {
            string content = client.DownloadString(Url);
            return content;
        }

    }
}
