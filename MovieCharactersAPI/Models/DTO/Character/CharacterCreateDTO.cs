using MovieCharactersAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Character
{
    /// <summary>
    /// Data transfer object for Character creation.
    /// </summary>
    public class CharacterCreateDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureURL { get; set; }
    }
}
