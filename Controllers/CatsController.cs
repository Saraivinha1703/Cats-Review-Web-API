using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CatsReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : Controller
    {
        private readonly ICatRepository _catRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CatsController(ICatRepository repository, IOwnerRepository ownerRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _catRepository = repository;
            _categoryRepository = categoryRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cat>))]
        public IActionResult GetCats()
        {
            List<CatDto> cats = _mapper.Map<List<CatDto>>(_catRepository.GetValues());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cats);
        }

        //How to pass on variable in the url, like: "http://localhost/api/controller?id={number}"
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Cat))]
        [ProducesResponseType(400)]
        public IActionResult GetCat(int id)
        {
            CatDto cat = _mapper.Map<CatDto>(_catRepository.GetValue(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cat);
        }

        [HttpGet("ownerByCat/{catId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerByCat(int catId)
        {
            OwnerDto cat = _mapper.Map<OwnerDto>(_catRepository.GetOwnerByCat(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cat);
        }

        [HttpGet("catReviews/{catId}")]
        [ProducesResponseType(200, Type = typeof(List<ReviewDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetCatReviews(int catId)
        {
            List<ReviewDto> cat = _mapper.Map<List<ReviewDto>>(_catRepository.GetCatReviews(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cat);
        }

        [HttpGet("catReviewers/{catId}")]
        [ProducesResponseType(200, Type = typeof(List<ReviewerDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetCatReviewers(int catId)
        {
            List<ReviewerDto> cat = _mapper.Map<List<ReviewerDto>>(_catRepository.GetCatReviewers(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cat);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCat([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] CatDto createCat)
        {
            if (createCat == null)
                BadRequest(ModelState);

            var cat = _catRepository.GetValues().Where(c => c.Name?.Trim().ToUpper() == createCat?.Name?.TrimEnd().ToUpper()).FirstOrDefault();

            if (cat != null)
            {
                ModelState.AddModelError("", "Cat already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var catMap = _mapper.Map<Cat>(createCat);
            Owner? catOwnerEntity = _ownerRepository.GetValue(ownerId);
            Category? catCategory = _categoryRepository.GetValue(categoryId);

            CatOwner catOwner = new CatOwner(){Owner = catOwnerEntity, Cat = catMap};
            
            if (!_catRepository.CreateObject(catMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Soccessfully created");
        }
    }

}