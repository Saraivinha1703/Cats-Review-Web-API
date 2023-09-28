using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatsReviewWebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        public IActionResult GetReviewers() {
            List<ReviewerDto> reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetValues());

            if(!ModelState.IsValid)
            BadRequest(ModelState);
            
            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        public IActionResult GetReviewer(int reviewerId) {
            ReviewerDto reviewers = _mapper.Map<ReviewerDto>(_reviewerRepository.GetValue(reviewerId));

            if(!ModelState.IsValid)
            BadRequest(ModelState);
            
            return Ok(reviewers);
        }

        [HttpGet("reviewerReviews/{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        public IActionResult GetReviewerReviews(int reviewerId) {
            List<ReviewDto> reviewers = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewerReviews(reviewerId));

            if(!ModelState.IsValid)
            BadRequest(ModelState);
            
            return Ok(reviewers);
        }
    }
}