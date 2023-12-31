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
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ICatRepository _catRepository;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, ICatRepository catRepository, IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _catRepository = catRepository;
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReviews()
        {
            List<ReviewDto> reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetValues());
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReview(int reviewId)
        {
            ReviewDto reviews = _mapper.Map<ReviewDto>(_reviewRepository.GetValue(reviewId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("reviewerByReview/{reviewId}")]
        [ProducesResponseType(200, Type = typeof(ReviewerDto))]
        public IActionResult GetReviewerByReview(int reviewId)
        {
            ReviewerDto reviews = _mapper.Map<ReviewerDto>(_reviewRepository.GetReviewerByReview(reviewId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("catByReview/{reviewId}")]
        [ProducesResponseType(200, Type = typeof(CatDto))]
        public IActionResult GetCatByReview(int reviewId)
        {
            CatDto reviews = _mapper.Map<CatDto>(_reviewRepository.GetCatByReview(reviewId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int catId, [FromQuery] int reviewerId, [FromBody] ReviewDto createReview)
        {
            if (createReview == null)
                BadRequest(ModelState);

            var review = _reviewRepository.GetValues().Where(c => c.Title?.Trim().ToUpper() == createReview?.Title?.TrimEnd().ToUpper()).FirstOrDefault();

            if (review != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(createReview);
            reviewMap.Reviewer = _reviewerRepository.GetValue(reviewerId);
            reviewMap.Cat = _catRepository.GetValue(catId);

            if (!_reviewRepository.CreateObject(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Soccessfully created");
        }
    }
}