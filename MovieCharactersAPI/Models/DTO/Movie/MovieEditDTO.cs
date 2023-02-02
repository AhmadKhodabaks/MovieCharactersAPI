namespace MovieCharactersAPI.Models.DTO.Movie
{
    /// <summary>
    /// Data transfer object for Movie editing.
    /// </summary>
    public class MovieEditDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string? PictureURL { get; set; }
        public string? TrailerURl { get; set; }
        public int FranchiseId { get; set; }
    }
}
