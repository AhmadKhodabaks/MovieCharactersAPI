using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.DTO.Character
{
    /// <summary>
    /// Data transfer object for Character reading.
    /// </summary>
    public class CharacterReadDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string PictureURL { get; set; }
        public List<int>? MovieIds { get; set; }
    }
}
