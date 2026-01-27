using PruebaAPI3.DTOs;
using System.Text.Json;

namespace PruebaAPI3.Services
{
    public class PostService : IPostService
    {
        private HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            if (_httpClient == null)
                throw new InvalidOperationException("HttpClient no inyectado.");

            var requestUri = _httpClient.BaseAddress?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(requestUri))
                throw new InvalidOperationException("BaseAddress no configurada en HttpClient.");

            var body = await _httpClient.GetStringAsync(requestUri);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var posts = JsonSerializer.Deserialize<IEnumerable<Post>>(body, jsonOptions);

            return posts;
        }
        public bool ValidarTitle(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 25)
            {
                return false;
            }
            return true;
        }
    }
}
