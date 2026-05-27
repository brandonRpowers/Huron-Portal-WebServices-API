using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace PortalAPI
{
    public class HuronAPI
    {
        /// <summary>
        /// GETs data from a Portal WebServices API.
        /// </summary>
        /// <param name="baseUrl">base url of the application, https://server/store</param>
        /// <param name="apiPath">Name of the WebService API</param>
        /// <param name="credential">base64 encoded username:password</param>
        /// <returns></returns>
        public static HuronAPIData GetAPIData(string baseUrl, string apiPath, string credential) {
            var client = new HttpClient();

            var url = $"{baseUrl}/api/click/datamanagement/{apiPath}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

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

        /// <summary>
        /// Sends a PUT request to update data at the specified API path and returns the response body.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API host.</param>
        /// <param name="apiPath">The relative data management API path to update.</param>
        /// <param name="credential">The Base64-encoded Basic authentication credential.</param>
        /// <param name="json">
        /// The JSON payload to send in the request body. The payload should use the following format:
        /// <code>
        /// {
        ///   &quot;Name&quot;: &quot;CoI eProposal&quot;,
        ///   &quot;Value&quot;: &quot;ID00001&quot;,
        ///   &quot;ValueIdentifier&quot;: &quot;ID&quot;,
        ///   &quot;Attributes&quot;: [
        ///     {
        ///       &quot;Caption&quot;: &quot;Caption1&quot;,
        ///       &quot;Value&quot;: &quot;value1&quot;
        ///     },
        ///     {
        ///       &quot;Caption&quot;: &quot;Caption2&quot;,
        ///       &quot;Value&quot;: &quot;value2&quot;
        ///     }
        ///   ]
        /// }
        /// </code>
        /// </param>
        /// <returns>The response body returned by the API.</returns>
        public static string UpdateAPIData(string baseUrl, string apiPath, string credential, string json)
        {
            var client = new HttpClient();

            var url = $"{baseUrl}/api/click/datamanagement/{apiPath}";

            Console.WriteLine(url);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            request.Headers.Add("Authorization", $"Basic {credential}");

            request.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

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

            return body;
        }

        /// <summary>
        /// Sends a POST request to add data at the specified API path and returns the response body.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API host.</param>
        /// <param name="apiPath">The relative data management API path where data will be added.</param>
        /// <param name="credential">The Base64-encoded Basic authentication credential.</param>
        /// <param name="json">
        /// The JSON payload to send in the request body. The payload should use the following format:
        /// <code>
        /// {
        ///   &quot;Name&quot;: &quot;WebServiceName&quot;,
        ///   &quot;Attributes&quot;: [
        ///     {
        ///       &quot;Caption&quot;: &quot;PropertyName&quot;,
        ///       &quot;Value&quot;: &quot;value1&quot;
        ///     },
        ///     {
        ///       &quot;Caption&quot;: &quot;PropertyName&quot;,
        ///       &quot;Value&quot;: &quot;value2&quot;
        ///     }
        ///   ]
        /// }
        /// </code>
        /// </param>
        /// <returns>The response body returned by the API.</returns>
        public static string AddAPIData(string baseUrl, string apiPath, string credential, string json)
        {
            var client = new HttpClient();

            var url = $"{baseUrl}/api/click/datamanagement/{apiPath}";

            Console.WriteLine(url);

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Headers.Add("Authorization", $"Basic {credential}");

            request.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

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

            return body;
        }
    }
}
