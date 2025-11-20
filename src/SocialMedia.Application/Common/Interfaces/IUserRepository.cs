using SocialMedia.Domain.Entities;

namespace SocialMedia.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}

