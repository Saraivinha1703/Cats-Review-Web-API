using AutoMapper;
using CatsReviewWebAPI.Dto;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Helper {
    //How does it work?
        public class MappingProfiles : Profile {
        public MappingProfiles()
        {
            CreateMap<Cat, CatDto>();
        }
    }
}