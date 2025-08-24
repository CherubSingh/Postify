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
        //POST: https://localhost:7096/api/Categories
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

        //Get: https://localhost:7096/api/Categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingcategory = await categoryRepository.GetByIdAsync(id);
            if(existingcategory == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            var response = new CategoryDto
            {
                Id = existingcategory.Id,
                Name = existingcategory.Name,
                UrlHandle = existingcategory.UrlHandle
            };
            return Ok(response);
        }

        //Put: https://localhost:7096/api/Categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UdateCategoryRequestDto request)
        {
            //convert DTo to Domain Model
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            category = await categoryRepository.UpdateAsync(category);
            if(category==null)
            {
                return NotFound();
            }

            //convert Domain Model to DTo
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        //Delete: https://localhost:7096/api/Categories/{id}
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DelecteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteAsync(id);

            if (category==null)
            {
                return NotFound();
            }

            //convert Domain model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }
    }
}
