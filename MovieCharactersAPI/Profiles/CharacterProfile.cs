using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Character;

namespace MovieCharactersAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterReadDTO, Character>();
            CreateMap<CharacterEditDTO, Character>();

        }
    }
}
