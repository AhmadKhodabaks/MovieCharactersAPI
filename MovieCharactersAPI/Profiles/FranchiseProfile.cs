using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Franchise;

namespace MovieCharactersAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(frDTO => frDTO.MovieIds, opt => opt
                .MapFrom(fr => fr.Movies.Select(mv => mv.MovieId).ToArray()));
            CreateMap<FranchiseEditDTO, Franchise>();
            CreateMap<FranchiseCreateDTO, Franchise>();
        }
    }
}
