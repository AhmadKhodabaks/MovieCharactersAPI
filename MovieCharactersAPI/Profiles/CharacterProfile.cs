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
                .ForMember(chDTO => chDTO.MovieIds, opt => opt
                .MapFrom(ch => ch.Movies.Select(m => m.MovieId).ToArray()));
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}
