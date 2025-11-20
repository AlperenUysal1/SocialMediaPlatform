using System;

namespace SocialMedia.Application.DTOs
{
    public class CreatePostDto
    {
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }
}

