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
    }
}