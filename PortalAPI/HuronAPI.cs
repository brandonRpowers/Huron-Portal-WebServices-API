using System;
using System.Net.Http;
using System.Text.Json;

namespace PortalAPI
{
    public class HuronAPI
    {
        /// <summary>
        /// GETs data from a Portal WebServices API.
        /// </summary>
        /// <param name="domain">Domain of the application</param>
        /// <param name="apiPath">Name of the WebService API</param>
        /// <param name="credential">base64 encoded username:password</param>
        /// <returns></returns>
        public static HuronAPIData GetAPIData(string domain, string apiPath, string credential) {
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

            var data = JsonSerializer.Deserialize<HuronAPIData>(body);

            return data;
        }
    }
}
