using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project1.Models;

namespace project1.Controllers
{
    [ApiController]
    [Route("api/categories/")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();

        //GET
        [HttpGet]
        public IActionResult GetCategories([FromQuery] string searchValue = "")
        {
            if (searchValue != null)
            {
                var searchCategories = categories.Where(c => c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                return Ok(searchCategories);
            }
            return Ok(categories);
        }

        //POST
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category categoryData)
        {
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = categoryData.Name,
                Description = categoryData.Description,
                CreatedAt = DateTime.UtcNow,

            };
            categories.Add(newCategory);
            return Created($"/api/categories/{newCategory.CategoryId}", newCategory);
        }

        //PUT
        [HttpPut("{categoryId:guid}")]
        public IActionResult UpdateCategoryById(Guid categoryId, [FromBody] Category categoryData)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
            if (foundCategory == null)
            {
                return NotFound("Does not exit!!!");
            }
            foundCategory.Name = categoryData.Name;
            foundCategory.Description = categoryData.Description;
            return NoContent();
        }

        //DELETE
        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategoryById(Guid categoryId)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
            if (foundCategory == null)
            {
                return NotFound("Does not exit");
            }
            categories.Remove(foundCategory);
            return NoContent();
        }
    }
}