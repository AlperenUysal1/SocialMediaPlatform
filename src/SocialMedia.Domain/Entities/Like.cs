namespace SocialMedia.Domain.Entities
{
    public class Like
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}

