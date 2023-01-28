using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Franchise
{
    public class FranchiseEditDTO
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
