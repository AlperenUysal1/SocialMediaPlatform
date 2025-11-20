using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Common.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetPostsByUserIdAsync(Guid userId);
    }
}

