using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Helper {
    //How does it work?
        public class MappingProfiles : Profile {
        public MappingProfiles()
        {
            CreateMap<Cat, CatDto>();
            CreateMap<CatDto, Cat>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
            
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();
        }
    }
}