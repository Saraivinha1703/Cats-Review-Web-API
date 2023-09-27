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

        public CatsController(IRepository<Cat> repository)
        {
            _catRepository = repository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cat>))]
        public IActionResult GetCats()
        {
            var cats = _catRepository.GetValues();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cats);
        }
    }

}