namespace MovieCharactersAPI.Models.DTO.Franchise
{
    public class FranchiseCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int>? MovieIds { get; set; }
    }
}
