using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postify.API.Models.Domain;
using Postify.API.Models.DTO;
using Postify.API.Repositories.Interface;

namespace Postify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        // POST: /api/BlogPosts
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto requestDto)
        {
            //convert DTO to Domain model
            var blogPost = new BlogPost
            {
                Author = requestDto.Author,
                Content = requestDto.Content,
                FeaturedImageUrl = requestDto.FeaturedImageUrl,
                IsVisible = requestDto.IsVisible,
                PublishedDate = requestDto.PublishedDate,
                ShortDescription = requestDto.ShortDescription,
                Title = requestDto.Title,
                UrlHandle = requestDto.UrlHandle
            };

            await blogPostRepository.CreateAsync(blogPost);

            //convert DOmain model to DTO
            var response=new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle
            };

            return Ok(response);
        }
    }
}
