using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Movie;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieEditDTO, Movie>();
            CreateMap<MovieReadDTO, Movie>();
        }
    }
}
