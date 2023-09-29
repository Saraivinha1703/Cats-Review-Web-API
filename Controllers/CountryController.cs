using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatsReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetValues());
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountry(int countryId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetValue(countryId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("countryByOwner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("ownersByCountry/{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetOwnersByCountry(int countryId)
        {
            var country = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersByContry(countryId));
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto createCountry)
        {
            if (createCountry == null)
                BadRequest(ModelState);

            var country = _countryRepository.GetValues().Where(c => c.Name?.Trim().ToUpper() == createCountry?.Name?.TrimEnd().ToUpper()).FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Cat already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(createCountry);
            if (!_countryRepository.CreateObject(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto createCountry)
        {
            if (createCountry == null)
                BadRequest(ModelState);

            if (countryId != createCountry?.Id)
                BadRequest(ModelState);

            var cat = _countryRepository.GetValues().Where(c => c.Id == createCountry?.Id).FirstOrDefault();

            if (cat == null)
                NotFound();

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(createCountry);
            if (!_countryRepository.UpdateObject(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }
    }
}