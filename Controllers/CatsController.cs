using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatsReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : Controller
    {
        private readonly IRepository<Cat> _catRepository;
        private readonly IMapper _mapper;

        public CatsController(IRepository<Cat> repository, IMapper mapper)
        {
            _catRepository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cat>))]
        public IActionResult GetCats()
        {
            var cats = _mapper.Map<List<CatDto>>(_catRepository.GetValues());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cats);
        }

        //How to pass on variable in the url, like: "http://localhost/api/controller?id={number}"
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Cat))]
        [ProducesResponseType(400)]
        public IActionResult GetCat(int id) {
            var cat = _mapper.Map<CatDto>(_catRepository.GetValue(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cat);
        }
    }

}