using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatsReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
        public IActionResult GetOwners()
        {
            List<OwnerDto> owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetValues());

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(OwnerDto))]
        public IActionResult GetOwner(int ownerId)
        {
            OwnerDto owner = _mapper.Map<OwnerDto>(_ownerRepository.GetValue(ownerId));

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("catByOwner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(CatDto))]
        public IActionResult GetCatByOwner(int ownerId)
        {
            CatDto cat = _mapper.Map<CatDto>(_ownerRepository.GetCatByOwner(ownerId));

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(cat);
        }

        [HttpGet("countryByOwner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            CountryDto country = _mapper.Map<CountryDto>(_ownerRepository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(country);
        }

       [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int countryId, [FromBody] OwnerDto createOwner)
        {
            if (createOwner == null)
                BadRequest(ModelState);

            var owner = _ownerRepository.GetValues().Where(c => c.Name?.Trim().ToUpper() == createOwner?.Name?.TrimEnd().ToUpper()).FirstOrDefault();

            if (owner != null)
            {
                ModelState.AddModelError("", "Cat already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var ownerMap = _mapper.Map<Owner>(createOwner);
            ownerMap.Country = _countryRepository.GetValue(countryId);
            if (!_ownerRepository.CreateObject(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Soccessfully created");
        }

    }
}