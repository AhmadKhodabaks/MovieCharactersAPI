using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Franchise;

namespace MovieCharactersAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<FranchiseCreateDTO, Franchise>();
            CreateMap<FranchiseEditDTO, Franchise>().ReverseMap();
            CreateMap<FranchiseReadDTO, Franchise>();
        }
    }
}
