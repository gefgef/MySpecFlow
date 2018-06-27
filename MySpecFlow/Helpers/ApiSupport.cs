using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using NUnit;

using System.Net;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;

namespace MySpecFlow.Helpers
{
    //TODO: API TESTS WIP
    public static class ApiSupport
    {
        private static RestClient client;
        private static string frontendUrl = ConfigurationManager.AppSettings.Get("tst.frontent.url");
        private static string backendUrl = ConfigurationManager.AppSettings.Get("tst.backend.url");

        public static string[] LoginAndGetAccessTokenSessionId(string username, string pass)
        {
            client = new RestClient(backendUrl);
            client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest("/api/sitecore/v2/token", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", pass);
            IRestResponse<OauthResponse> response = client.Execute<OauthResponse>(request);

            var APIv2SessionID = Regex.Match((string)response.Headers.FirstOrDefault(m => m.Name == "Set-Cookie").Value,
                "APIv2SessionID=([^;]+);").Groups[1].Value;

            return new string[] { response.Data.access_token, APIv2SessionID };
        }

        public static void OpenPage(string URL, string accessToken, string sessionId)
        {
            try
            {
                client = new RestClient(frontendUrl);
                //client.BaseUrl = new Uri("https://tst-medischevoeding.mediq.nl");

                RestRequest request = new RestRequest("/", Method.GET);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;

                IRestResponse response = client.Execute(request);


                Console.Write("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


    }
}
