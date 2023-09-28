using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatsReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
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
    }
}