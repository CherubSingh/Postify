using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postify.API.Data;
using Postify.API.Models.Domain;
using Postify.API.Models.DTO;
using Postify.API.Repositories.Interface;

namespace Postify.API.Controllers
{
    //https://localhost:7096/api/categories

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            //Call repository to save the category
            await categoryRepository.CreateAsync(category);

            //Domain to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }


        //GET: https://localhost:7096/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            //Call repository to get all categories
            var categories = await categoryRepository.GetAllAsync();

            //Map Domain Model to DTO
            var response = new List<CategoryDto>();
            foreach(var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }
            return Ok(response);
        }
    }
}
