using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text.Json;
using System.Threading.Tasks;
using KawaiiAPI.NET.Enums;



namespace KawaiiAPI.NET
{
    public class KawaiiClient
    {
        private readonly HttpClient _httpClient;
        private const string _baseUrl = "https://kawaii.red/api/gif/";
        private readonly string _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="KawaiiClient"/> class.
        /// If no token is provided, the client will use the anonymous token.
        /// </summary>
        public KawaiiClient(string token = "anonymous")
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
            _token = token;
        }

        /// <summary>
        /// Returns a random GIF URL from the specified endpoint.
        /// </summary>
        /// <exception cref="AuthenticationException">Throws when a invalid Auth Token is provided.</exception>
        public async Task<string> GetRandomGifAsync(KawaiiGifType type)
        {
            var response = await _httpClient.GetAsync($"{type}?token={_token}");
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            using JsonDocument document = JsonDocument.Parse(jsonResponse);
            if (document.RootElement.TryGetProperty("error", out JsonElement errorResponse))
            {
                if (errorResponse.GetString().Contains("Invalid authentication token!"))
                {
                    throw new AuthenticationException(errorResponse.GetString());
                }

            }
            if (document.RootElement.TryGetProperty("response", out JsonElement responseElement))
            {
                string? gifUrl = responseElement.GetString();
                return gifUrl;
            }
            else
            {
                throw new JsonException("Invalid JSON response. Missing 'response' property.");
            }
        }
    }
}