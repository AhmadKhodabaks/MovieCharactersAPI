using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.DTO.Character
{
    public class CharacterReadDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string PictureURL { get; set; }
        public List<int>? MovieIds { get; set; }
    }
}
