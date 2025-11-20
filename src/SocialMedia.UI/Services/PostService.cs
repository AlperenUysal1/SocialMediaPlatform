using SocialMedia.Application.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SocialMedia.UI.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostDto>> GetPostsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<PostDto>>("api/posts") ?? new List<PostDto>();
            }
            catch
            {
                return new List<PostDto>();
            }
        }

        public async Task CreatePostAsync(CreatePostDto post)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/posts", post);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating post: {ex.Message}");
                throw;
            }
        }
    }
}

