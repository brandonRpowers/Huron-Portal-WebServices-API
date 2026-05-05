using System;
using System.Net.Http;
using System.Text.Json;

namespace PortalAPI
{
    public class HuronAPI
    {
        public static HuronAPIData GetAPIData(string domain, string apiPath, string credential) {
            var url = "erica.research.utah.edu/erica";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{domain}/api/click/datamanagement/{apiPath}");
            request.Headers.Add("Authorization", $"Basic {credential}");

            HttpResponseMessage response = client
                .SendAsync(request)
                .GetAwaiter()
                .GetResult();

            response.EnsureSuccessStatusCode();

            string body = response
                .Content
                .ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();

            Console.WriteLine(body);
            var data = JsonSerializer.Deserialize<HuronAPIData>(body);

            return data;
        }
    }
}
