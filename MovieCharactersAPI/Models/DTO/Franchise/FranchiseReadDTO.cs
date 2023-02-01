namespace MovieCharactersAPI.Models.DTO.Franchise
{
    public class FranchiseReadDTO
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int>? MovieIds { get; set; }
    }
}
