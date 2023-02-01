using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Franchise;

namespace MovieCharactersAPI.Profiles
{
    /// <summary>
    /// Profile class for Franchise.
    /// Creates auto-mapping from/to Frachise to/from Franchise data transfer objects.
    /// </summary>
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(frDTO => frDTO.MovieIds, opt => opt // maps from List with Movie objects to an array with Movie PKs.
                .MapFrom(fr => fr.Movies.Select(mv => mv.MovieId).ToArray()));
            CreateMap<FranchiseEditDTO, Franchise>();
            CreateMap<FranchiseCreateDTO, Franchise>();
        }
    }
}
