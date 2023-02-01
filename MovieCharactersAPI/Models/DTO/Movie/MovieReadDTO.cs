using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Movie
{
    /// <summary>
    /// Data transfer object for Movie reading.
    /// </summary>
    public class MovieReadDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureURL { get; set; }
        public string TrailerURl { get; set; }
        public int FranchiseId { get; set; }
        public List<int>? CharacterIds { get; set; }
    }
}
