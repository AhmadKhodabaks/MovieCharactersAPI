using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Character;

namespace MovieCharactersAPI.Profiles
{
    /// <summary>
    /// Profile class for Character.
    /// Creates auto-mapping from/to Character to/from Character data transfer objects.
    /// </summary>
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(chDTO => chDTO.MovieIds, opt => opt // maps from List with Movie objects to an array with Movie PKs.
                .MapFrom(ch => ch.Movies.Select(m => m.MovieId).ToArray()));
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}
