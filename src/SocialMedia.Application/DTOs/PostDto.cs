using System;

namespace SocialMedia.Application.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}

