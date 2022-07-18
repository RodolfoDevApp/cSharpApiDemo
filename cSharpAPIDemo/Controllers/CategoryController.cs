using AutoMapper;
using cSharpAPIDemo.Models;
using cSharpAPIDemo.Models.Dtos;
using cSharpAPIDemo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cSharpAPIDemo.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _ctRepo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var listCategories = _ctRepo.GetCategories();
            var listCategoriesDto = new List<CategoryDto>();
            foreach (var category in listCategories)
            {
                listCategoriesDto.Add(_mapper.Map<CategoryDto>(category));
            }
            return Ok(listCategoriesDto);
        }
        [HttpGet("{categoryId:int}", Name ="GetCategory")]
        public IActionResult GetCategory(int categoryId)
        {
            var itemCategory = _ctRepo.GetCategory(categoryId);
            if (itemCategory == null)
            {
                return NotFound();
            }
            var itemCategoryDto = _mapper.Map<CategoryDto>(itemCategory);
            return Ok(itemCategoryDto);
        }
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_ctRepo.CategoryExists(categoryDto.Name))
            {
                ModelState.AddModelError("", "The category already exist");
                return StatusCode(404, ModelState);
            }
            var category = _mapper.Map<Category>(categoryDto);
            if (!_ctRepo.CreateCategory(category))
            {
                ModelState.AddModelError("", $"there was a problem saving the category {category.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCategory", new { categoryId = category.id }, category);
        }
        [HttpPatch("{categoryId:int}", Name = "UdateCategory")]
        public IActionResult UpdateCategory(int categoryId, [FromBody]CategoryDto categoryDto)
        {
            if (categoryDto == null || categoryId != categoryDto.id)
            {
                return BadRequest(ModelState);
            }
            var category = _mapper.Map<Category>(categoryDto);
            if (!_ctRepo.UpdateCategory(category))
            {
                ModelState.AddModelError("", $"There was a problem updating the category{category.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_ctRepo.CategoryExists(categoryId))
            {
                return NotFound();
            }
            var category = _ctRepo.GetCategory(categoryId);
            if (!_ctRepo.DeleteCategory(category))
            {
                ModelState.AddModelError("", $"There was a problem deleting the category {category.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
