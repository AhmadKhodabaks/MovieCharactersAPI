using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Movie;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(mvDTO => mvDTO.CharacterIds, opt => opt
                .MapFrom(mv => mv.Characters.Select(ch => ch.CharacterId).ToArray()));
            CreateMap<MovieEditDTO, Movie>();
            CreateMap<MovieCreateDTO, Movie>();
        }
    }
}
