using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Helper {
    //How does it work?
        public class MappingProfiles : Profile {
        public MappingProfiles()
        {
            CreateMap<Cat, CatDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}