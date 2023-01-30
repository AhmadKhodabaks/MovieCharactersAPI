using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Character;

namespace MovieCharactersAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(cdto => cdto.MovieIds, opt => opt
                .MapFrom(c => c.Movies.Select(c => c.MovieId).ToArray()));
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}
