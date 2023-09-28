using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;
using CatsReviewWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CatsReviewWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetValues());
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetValue(categoryId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("cats/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cat>))]
        [ProducesResponseType(400)]
        public IActionResult GetCatsByCategory(int categoryId)
        {
            var cats = _mapper.Map<List<CatDto>>(_categoryRepository.GetCatsByCategory(categoryId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);
            return Ok(cats);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto createCategory)
        {
            if (createCategory == null)
                BadRequest(ModelState);

            var category = _categoryRepository.GetValues().Where(c => c.Breed?.Trim().ToUpper() == createCategory?.Breed?.TrimEnd().ToUpper()).FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(createCategory);
            if (!_categoryRepository.CreateObject(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Soccessfully created");
        }
    }
}