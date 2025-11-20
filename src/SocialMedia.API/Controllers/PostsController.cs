using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Common.Interfaces;
using SocialMedia.Domain.Entities;
using System;
using System.Threading.Tasks;
using SocialMedia.Application.DTOs;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostsController(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postRepository.GetAllAsync();
            var postDtos = posts.Select(p => new PostDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedOn = p.CreatedOn
            });
            return Ok(postDtos);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var posts = await _postRepository.GetPostsByUserIdAsync(userId);
            var postDtos = posts.Select(p => new PostDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedOn = p.CreatedOn
            });
            return Ok(postDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto postDto)
        {
            // 1. Check if user exists, if not create a demo user
            var user = await _userRepository.GetByIdAsync(postDto.UserId);
            if (user == null)
            {
                user = new User
                {
                    Id = postDto.UserId,
                    Username = "DemoUser",
                    Email = $"demo_{postDto.UserId}@example.com",
                    PasswordHash = "dummyhash"
                };
                await _userRepository.AddAsync(user);
            }

            // 2. Create the post
            var post = new Post
            {
                Content = postDto.Content,
                ImageUrl = postDto.ImageUrl,
                UserId = postDto.UserId
            };

            var createdPost = await _postRepository.AddAsync(post);
            
            // Return DTO instead of Entity to avoid circular reference
            var resultDto = new PostDto
            {
                Id = createdPost.Id,
                UserId = createdPost.UserId,
                Content = createdPost.Content,
                ImageUrl = createdPost.ImageUrl,
                CreatedOn = createdPost.CreatedOn
            };

            return CreatedAtAction(nameof(GetByUserId), new { userId = createdPost.UserId }, resultDto);
        }
    }
}

