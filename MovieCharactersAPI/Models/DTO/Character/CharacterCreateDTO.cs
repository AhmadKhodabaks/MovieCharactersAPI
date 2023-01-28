using MovieCharactersAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Character
{
    public class CharacterCreateDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string PictureURL { get; set; }
    }
}
