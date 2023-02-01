using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Movie;

namespace MovieCharactersAPI.Profiles
{
    /// <summary>
    /// Profile class for Movie.
    /// Creates auto-mapping from/to Movie to/from Movie data transfer objects.
    /// </summary>
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(mvDTO => mvDTO.CharacterIds, opt => opt // maps from List with Character objects to an array with Character PKs.
                .MapFrom(mv => mv.Characters.Select(ch => ch.CharacterId).ToArray()));
            CreateMap<MovieEditDTO, Movie>();
            CreateMap<MovieCreateDTO, Movie>();
        }
    }
}
